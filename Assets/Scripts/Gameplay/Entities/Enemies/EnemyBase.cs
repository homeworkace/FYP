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

public enum ENEMYTYPE
{
    FOOTSOLDIER,
    TANK,
    SCOUT,
    ARTILLERY,
    SNIPER
}

public class EnemyBase : EntityBase
{
    public ENEMYTYPE type;
    public NavMeshAgent agent;
    public List<EnemyBase> enemiesInRange = new List<EnemyBase>();
    public List<EnemyBase> enemiesThatCanSeeYou = new List<EnemyBase>();
    public List<StructureBase> structuresInRange = new List<StructureBase>();
    public List<StructureBase> structuresThatCanSeeYou = new List<StructureBase>();

    EnemyBase closestEnemy = null;
    StructureBase closestStructure = null;

    public STRATEGY strategy;
    public List<int> squadIDs = new List<int>();

    
    private Quaternion dir = Quaternion.identity;
    public EntityBase targetEntity;

    public GameObject deathParticle;

    private bool isAttacking = false;

    private void Awake()
    {
        maxhealth = health;
        CreateHealthBar();
    }
    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
        collider = GetComponent<Collider>();
        object[] data = view.InstantiationData;
        faction = (FACTION)data[0];

        agent = GetComponent<NavMeshAgent>();
        agent.speed = movement/100;
        agent.acceleration = float.MaxValue;
        agent.updateRotation = false;
        strategy = STRATEGY.ATTACK;
        transform.parent = GameObject.Find("Environment").transform.Find("Enemies");
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
        HealthBarUpdate();

        if (view.IsMine)
        DetectEnemiesInViewRange();

        //if (view.IsMine == false)
        //{
        //    if (enemiesThatCanSeeYou.Count > 0)
        //        GetComponent<Renderer>().enabled = true;
        //    else
        //        GetComponent<Renderer>().enabled = false;
        //}
        if (view.IsMine)
        {
            PathMovement();
            if (attackRange > 0)
            AttackUpdate();

            DeathUpdate();
        }
    }

    private void LateUpdate()
    {
        RotationUpdate();
    }

    public void DeathUpdate()
    {
        if (health <= 0)
        {
            CreateDeathParticles();
            //DELETION OF OBJECT
            PhotonNetwork.Destroy(gameObject);
        }
    }

    void RotationUpdate()
    {
        if (!transform.Find("Model"))
            return;
        //RaycastHit bottomHit;
        //int layer = (1 << LayerMask.NameToLayer("Terrain"));
        //Physics.Raycast(collider.bounds.center, Vector3.down, out bottomHit, Mathf.Infinity, layer);
        //Debug.DrawLine(collider.bounds.center, collider.bounds.center + Vector3.Cross(transform.Find("Model").right, bottomHit.normal)*1000);
        
        if (agent.desiredVelocity.normalized != Vector3.zero)
        dir = Quaternion.LookRotation(agent.desiredVelocity.normalized);

        transform.Find("Model").rotation = Quaternion.Slerp(transform.Find("Model").rotation, dir, 10* Time.deltaTime);
    }

    void AttackUpdate()
    {
        closestEnemy = null;
        closestStructure = null;
        bool targetEntityInRange = false;
        RaycastHit hitInfo;
        if (targetEntity != null)
        {
            Physics.Linecast(collider.bounds.center, targetEntity.collider.bounds.center, out hitInfo);
            if (hitInfo.transform == targetEntity.transform && Vector3.Distance(targetEntity.collider.bounds.center, collider.bounds.center) <= (attackRange / 100) * GridGenerator.Instance.singleGridSize)
            {
                targetEntityInRange = true;
                Debug.Log("Target Enemy In Range!");
            }
            else
            {
                agent.isStopped = false;
                agent.SetDestination(targetEntity.transform.position);
                agent.speed = movement / 100;
                isAttacking = false;
                Debug.Log("Target Enemy Not In Range!");
            }
        }
        if (isAttacking)
        {
            if (closestEnemy == null && closestStructure == null && targetEntityInRange == false)
            {
                isAttacking = false;
                agent.speed = movement / 100;
            }
        }

        if (strategy != STRATEGY.ATTACK)
            return;
        
            if (targetEntityInRange == true)
            {
                isAttacking = true;
                agent.speed = 0;

                attackTimer += Time.deltaTime;
                if (attackTimer >= rateOfAttack)
                {
                    attackTimer = 0;
                    //DamageEnemy(closestEnemy);
                    GameManager.Instance.SpawnProjectile(bulletType, collider.bounds.center, targetEntity.view.ViewID, damage, bulletSpeed, faction);
                }
                return;
            }

        //Attack Enemy
        
        float closestDistance = float.MaxValue;
        foreach (EnemyBase enemy in enemiesInRange)
        {
            if (Vector3.Distance(enemy.collider.bounds.center, collider.bounds.center) < closestDistance)
            {
                closestEnemy = enemy;
            }
        }
        if (closestEnemy != null)
        {
            isAttacking = true;
            agent.speed = 0;

            attackTimer += Time.deltaTime;
            if (attackTimer >= rateOfAttack)
            {
                attackTimer = 0;
                //DamageEnemy(closestEnemy);
                GameManager.Instance.SpawnProjectile(bulletType,collider.bounds.center, closestEnemy.view.ViewID,damage,bulletSpeed,faction);
            }
            return;
        }

        //Attack Structure
        
        closestDistance = float.MaxValue;
        foreach (StructureBase structure in structuresInRange)
        {
            if (Vector3.Distance(structure.collider.bounds.center, collider.bounds.center) < closestDistance)
            {
                closestStructure = structure;
            }
        }
        if (closestStructure != null)
        {
            isAttacking = true;
            //agent.isStopped = true;

            attackTimer += Time.deltaTime;
            if (attackTimer >= rateOfAttack)
            {
                attackTimer = 0;
                //DamageStructure(closestStructure);
                GameManager.Instance.SpawnProjectile(bulletType, collider.bounds.center, closestStructure.view.ViewID, damage, bulletSpeed, faction);
            }
            return;
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
            Vector3 enemyPos = enemy.collider.bounds.center;
            enemyPos.y = 0;
            Vector3 myPos = collider.bounds.center;
            myPos.y = 0;
            if (Vector3.Distance(enemyPos, myPos) <= (attackRange/100) * GridGenerator.Instance.singleGridSize)
            {
                RaycastHit hitInfo;
                Physics.Linecast(collider.bounds.center, enemy.collider.bounds.center,out hitInfo);
                
                if (hitInfo.transform == enemy.transform && enemiesInRange.Exists(increment => increment == enemy) == false)
                    enemiesInRange.Add(enemy);
            }
            else
            {
                enemiesInRange.Remove(enemy);
            }

            if (Vector3.Distance(enemyPos, myPos) <= (vision/100) * GridGenerator.Instance.singleGridSize)
            {
                if (enemy.enemiesThatCanSeeYou.Exists(increment => increment == this) == false)
                    enemy.enemiesThatCanSeeYou.Add(this);
            }
            else
            {
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
            
            Vector3 buildingPos = building.collider.bounds.center;
            buildingPos.y = 0;
            Vector3 myPos = collider.bounds.center;
            myPos.y = 0;
            if (Vector3.Distance(buildingPos, myPos) <= (attackRange/100) * GridGenerator.Instance.singleGridSize)
            {
                RaycastHit hitInfo;
                Physics.Linecast(collider.bounds.center, building.collider.bounds.center, out hitInfo);
                if (hitInfo.transform == building.transform && structuresInRange.Exists(increment => increment == building) == false)
                    structuresInRange.Add(building);
            }
            else
            {
                structuresInRange.Remove(building);
            }

            if (Vector3.Distance(building.collider.bounds.center, collider.bounds.center) <= (vision/100) * GridGenerator.Instance.singleGridSize)
            {
                if (building.enemiesThatCanSeeYou.Exists(increment => increment == this) == false)
                    building.enemiesThatCanSeeYou.Add(this);
            }
            else
            {
                building.enemiesThatCanSeeYou.Remove(this);
            }
        }
    }

    void CreateDeathParticles()
    {
        if (PhotonNetwork.OfflineMode)
        {
            Instantiate(deathParticle, collider.bounds.center, Quaternion.identity, GameObject.Find("Environment").transform);
        }
        else
        {
            view.RPC("RPCCreateDeathParticles", RpcTarget.All);
        }
    }

    [PunRPC]
    void RPCCreateDeathParticles()
    {
        Instantiate(deathParticle, collider.bounds.center, Quaternion.identity,GameObject.Find("Environment").transform);
    }
}
