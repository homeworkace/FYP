using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.AI;

public enum STRATEGY
{
    ATTACK,
    PASSIVE
}

public class EnemyBase : EntityBase
{
    public NavMeshAgent agent;
    public List<EnemyBase> enemiesInRange = new List<EnemyBase>();
    public List<EnemyBase> enemiesThatCanSeeYou = new List<EnemyBase>();
    public List<StructureBase> structuresInRange = new List<StructureBase>();
    public List<StructureBase> structuresThatCanSeeYou = new List<StructureBase>();

    public PhotonView view;
    public STRATEGY strategy;

    private void Awake()
    {
        maxhealth = health;
        CreateHealthBar();
    }
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = movement/100;
        agent.acceleration = float.MaxValue;
        agent.updateRotation = false;
        strategy = STRATEGY.ATTACK;

        view = GetComponent<PhotonView>();
        transform.parent = GameObject.Find("Environment").transform.Find("Enemies");
        if (view.Owner != null)
            faction += view.Owner.ActorNumber - 1;
        else
            faction = FACTION.BLUE;
        
    }

    void RemoveDeadEnemiesAndStructures()
    {
        enemiesInRange.RemoveAll(increment => increment == null);
        enemiesThatCanSeeYou.RemoveAll(increment => increment == null);
        structuresInRange.RemoveAll(increment => increment == null);
        structuresThatCanSeeYou.RemoveAll(increment => increment == null);
}

    // Update is called once per frame
    void Update()
    {
        RemoveDeadEnemiesAndStructures();

        if (view.IsMine)
        DetectEnemiesInViewRange();

        if (view.IsMine == false)
        {
            if (enemiesThatCanSeeYou.Count > 0)
                GetComponent<Renderer>().enabled = true;
            else
                GetComponent<Renderer>().enabled = false;
        }
        if (view.IsMine)
        {
            Death();
            PathMovement();
            AttackUpdate();
        }
    }

    void Death()
    {
        if (health <= 0)
        PhotonNetwork.Destroy(gameObject);
    }

    void AttackUpdate()
    {
        if (strategy != STRATEGY.ATTACK)
            return;

        EnemyBase closestEnemy = null;
        float closestDistance = float.MaxValue;
        foreach (EnemyBase enemy in enemiesInRange)
        {
            if (Vector3.Distance(enemy.transform.position,transform.position) < closestDistance)
            {
                closestEnemy = enemy;
            }
        }
        if (closestEnemy != null)
        {
            attackTimer += Time.deltaTime;
            if (attackTimer >= rateOfAttack)
            {
                attackTimer = 0;
                Debug.Log("PUN RPC SHOULD BE CALLED");
                DamageEnemy(closestEnemy);
            }
        }
    }

    void PathMovement()
    {
        if (Vector3.Distance(agent.destination,transform.position) <= GridGenerator.Instance.singleGridSize)
        {
            agent.isStopped = true;
        }
    }

    void DetectEnemiesInViewRange()
    {
        foreach (Transform child in transform.parent)
        {
            EnemyBase enemy = child.gameObject.GetComponent<EnemyBase>();
            if (!enemy)
                continue;
            if (child == transform)
                continue;
            if (enemy.faction == faction)
                continue;
            Vector3 enemyPos = enemy.transform.position;
            enemyPos.y = 0;
            Vector3 myPos = transform.position;
            myPos.y = 0;
            if (Vector3.Distance(enemyPos, myPos) <= vision * GridGenerator.Instance.singleGridSize)
            {
                RaycastHit hitInfo;
                Physics.Linecast(transform.position, enemy.transform.position,out hitInfo);
                
                if (hitInfo.transform == enemy.transform && enemiesInRange.Exists(increment => increment == enemy) == false)
                    enemiesInRange.Add(enemy);
                if (enemy.enemiesThatCanSeeYou.Exists(increment => increment == this) == false)
                    enemy.enemiesThatCanSeeYou.Add(this);
            }
            else
            {
                enemiesInRange.Remove(enemy);
                enemy.enemiesThatCanSeeYou.Remove(this);
            }
        }

        // Handle seeing enemy's structures when in range
        foreach (Transform child in GameObject.Find("Environment").transform.Find("Structures"))
        {
            StructureBase building = child.gameObject.GetComponent<StructureBase>();

            if (!building)
                continue;
            if (building.faction == faction)
                continue;
            
            if (Vector3.Distance(building.transform.position, transform.position) <= vision * GridGenerator.Instance.singleGridSize)
            {
                if (structuresInRange.Exists(increment => increment == building) == false)
                {
                    structuresInRange.Add(building);
                }
                if (building.enemiesThatCanSeeYou.Exists(increment => increment == this) == false)
                {
                    building.enemiesThatCanSeeYou.Add(this);
                }
                else
                {
                    structuresInRange.Remove(building);
                    building.enemiesThatCanSeeYou.Remove(this);
                }
            }
        }
    }

    public void DamageEnemy(EnemyBase enemy)
    {
        if (PhotonNetwork.OfflineMode == false)
            enemy.view.RPC("RPC_GetDamaged", RpcTarget.All, damage);
        else
            enemy.health -= damage;
    }

    [PunRPC]
    void RPC_GetDamaged(int damageInput)
    {
        health -= damageInput;
    }
}
