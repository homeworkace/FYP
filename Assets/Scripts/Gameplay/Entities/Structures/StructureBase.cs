using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.AI;

public enum STRUCTURE_TYPE
{
    BASE,
    BARRICADE,
    HARVESTER,
    TURRET,

    NUM_STRUCTURE_TYPE
}

public class StructureBase : EntityBase
{
    public List<EnemyBase> enemiesInRange = new List<EnemyBase>();
    public List<EnemyBase> enemiesThatCanSeeYou = new List<EnemyBase>();
    public List<StructureBase> structuresInRange = new List<StructureBase>();
    public List<StructureBase> structuresThatCanSeeYou = new List<StructureBase>();
    RaycastHit hitInfo;
    public STRUCTURE_TYPE type;
   
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

        transform.parent = GameObject.Find("Environment").transform.Find("Structures");
        movement = 0; // Structures must NEVER move once placed down
    }

    // Update is called once per frame
    void Update()
    {
        HealthBarUpdate();
        RemoveDeadEnemiesAndStructures();
        if (view.IsMine)
        {
            DetectEnemiesAndStructuresInViewRange();
            if (attackRange > 0)
            AttackUpdate();

            DeathUpdate();
        }
    }

    public void AttackUpdate()
    {
        //Attack Enemy
        EnemyBase closestEnemy = null;
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
            attackTimer += Time.deltaTime;
            if (attackTimer >= rateOfAttack)
            {
                attackTimer = 0;
                GameManager.Instance.SpawnProjectile(bulletType, collider.bounds.center, closestEnemy.view.ViewID, damage, bulletSpeed, faction);
            }
            return;
        }

        //Attack Structure

        StructureBase closestStructure = null;
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
            attackTimer += Time.deltaTime;
            if (attackTimer >= rateOfAttack)
            {
                attackTimer = 0;
                GameManager.Instance.SpawnProjectile(bulletType, collider.bounds.center, closestStructure.view.ViewID, damage, bulletSpeed, faction);
            }
            return;
        }
    }

    public void DeathUpdate()
    {
        if (health <= 0)
        {
            //DELETION OF OBJECT
            PhotonNetwork.Destroy(gameObject);
        }
    }

    void RemoveDeadEnemiesAndStructures()
    {
        enemiesInRange.RemoveAll(increment => increment == null);
        enemiesThatCanSeeYou.RemoveAll(increment => increment == null);
        structuresInRange.RemoveAll(increment => increment == null);
        structuresThatCanSeeYou.RemoveAll(increment => increment == null);
    }

    void PlaceBuilding()
    {
    }

    public void DetectEnemiesAndStructuresInViewRange()
    {
        foreach (Transform child in transform.parent)
        {
            StructureBase structure = child.gameObject.GetComponent<StructureBase>();
            if (!structure)
                continue;
            if (child == transform)
                continue;
            if (structure.faction == faction || structure.faction == FACTION.NEUTRAL)
                continue;
            Vector3 structurePos = structure.collider.bounds.center;
            structurePos.y = 0;
            Vector3 myPos = collider.bounds.center;
            myPos.y = 0;
            if (Vector3.Distance(structurePos, myPos) <= (attackRange / 100) * GridGenerator.Instance.singleGridSize)
            {
                RaycastHit hitInfo;
                Physics.Linecast(collider.bounds.center, structure.collider.bounds.center, out hitInfo);

                if (hitInfo.transform == structure.transform && structuresInRange.Exists(increment => increment == structure) == false)
                    structuresInRange.Add(structure);
            }
            else
            {
                structuresInRange.Remove(structure);
            }

            if (Vector3.Distance(structurePos, myPos) <= (vision / 100) * GridGenerator.Instance.singleGridSize)
            {
                if (structure.structuresThatCanSeeYou.Exists(increment => increment == this) == false)
                    structure.structuresThatCanSeeYou.Add(this);
            }
            else
            {
                structure.structuresThatCanSeeYou.Remove(this);
            }
        }

        // Handle seeing enemy's structures when in range
        foreach (Transform child in GameObject.Find("Environment").transform.Find("Enemies"))
        {
            EnemyBase enemy = child.gameObject.GetComponent<EnemyBase>();
            if (!enemy)
                continue;
            if (enemy.faction == faction || enemy.faction == FACTION.NEUTRAL)
                continue;
            Vector3 enemyPos = enemy.collider.bounds.center;
            enemyPos.y = 0;
            Vector3 myPos = collider.bounds.center;
            myPos.y = 0;
            if (Vector3.Distance(enemyPos, myPos) <= (attackRange / 100) * GridGenerator.Instance.singleGridSize)
            {
                RaycastHit hitInfo;
                Physics.Linecast(collider.bounds.center, enemy.collider.bounds.center, out hitInfo);

                if (hitInfo.transform == enemy.transform && enemiesInRange.Exists(increment => increment == enemy) == false)
                    enemiesInRange.Add(enemy);
            }
            else
            {
                enemiesInRange.Remove(enemy);
            }

            if (Vector3.Distance(enemyPos, myPos) <= (vision / 100) * GridGenerator.Instance.singleGridSize)
            {
                if (enemy.structuresThatCanSeeYou.Exists(increment => increment == this) == false)
                    enemy.structuresThatCanSeeYou.Add(this);
            }
            else
            {
                enemy.structuresThatCanSeeYou.Remove(this);
            }
        }
    }
}
