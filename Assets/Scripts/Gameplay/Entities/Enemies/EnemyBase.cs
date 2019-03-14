using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public enum STRATEGY
{
    ATTACK,
    PASSIVE
}

public class EnemyBase : EntityBase
{
    public Vector3 gridPos = Vector2.zero;
    public List<int> path = new List<int>();
    public List<EnemyBase> enemiesInRange = new List<EnemyBase>();
    public List<EnemyBase> enemiesThatCanSeeYou = new List<EnemyBase>();
    public List<StructureBase> structuresInRange = new List<StructureBase>();
    public List<StructureBase> structuresThatCanSeeYou = new List<StructureBase>();

    public PhotonView view;
    public STRATEGY strategy;
    public int targetGridID;

    private void Awake()
    {
        maxhealth = health;
    }
    // Start is called before the first frame update
    void Start()
    {
        CreateHealthBar();
        strategy = STRATEGY.ATTACK;

        view = GetComponent<PhotonView>();
        transform.parent = GameObject.Find("Environment").transform.Find("Enemies");
        if (view.Owner != null)
            faction += view.Owner.ActorNumber - 1;
        else
            faction = FACTION.BLUE;
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

    public void FindPath(int gridID)
    {
        Debug.Log(gridID);
        GridGenerator.Instance.CalculateRoute(gameObject, GridGenerator.Instance.GridIDToGridPos(gridID));
        targetGridID = gridID;
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
        if (path.Count > 0 && enemiesInRange.Count <= 0)
        {
            FindPath(targetGridID);
            if (path.Count <= 0)
                return;
            Vector3 targetMovePosition = GridGenerator.Instance.GridIDToPosition(path[path.Count - 1]);
            Vector3 moveDir = (targetMovePosition - transform.position).normalized;
            moveDir.y = 0;
            transform.position += moveDir * 1 * Time.deltaTime;
            if (Vector3.Distance(targetMovePosition,transform.position) < GridGenerator.Instance.singleGridSize*0.5f)
            {
                path.RemoveAt(path.Count - 1);
            }
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

    void RemoveDeadEnemiesAndStructures()
    {
        enemiesInRange.RemoveAll(increment => increment == null);
        enemiesThatCanSeeYou.RemoveAll(increment => increment == null);
        structuresInRange.RemoveAll(increment => increment == null);
        structuresThatCanSeeYou.RemoveAll(increment => increment == null);
    }

    void Death()
    {
        if (health <= 0)
            PhotonNetwork.Destroy(gameObject);
    }

    [PunRPC]
    void RPC_GetDamaged(int damageInput)
    {
        health -= damageInput;
    }
}
