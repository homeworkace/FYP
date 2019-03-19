using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.AI;

public class StructureBase : EntityBase
{
    public Vector3 gridPos = Vector3.zero;
    public PhotonView view;
    public List<EnemyBase> enemiesInRange = new List<EnemyBase>();
    public List<EnemyBase> enemiesThatCanSeeYou = new List<EnemyBase>();
    public List<StructureBase> structuresInRange = new List<StructureBase>();
    public List<StructureBase> structuresThatCanSeeYou = new List<StructureBase>();
    RaycastHit hitInfo;
   
    private void Awake()
    {
        maxhealth = health;
    }

    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
        transform.parent = GameObject.Find("Environment").transform.Find("Structures");
        movement = 0; // Structures must NEVER move once placed down
        if (view.Owner != null)
            faction += view.Owner.ActorNumber - 1;
        else
            faction = FACTION.BLUE;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void PlaceBuilding()
    {
    }

    void DetectEnemiesInRange()
    {
        foreach (Transform child in transform.parent.parent.Find("Enemies"))
        {
            EnemyBase enemy = child.GetComponent<EnemyBase>();

            if (!enemy)
                continue;

            if (enemy.faction == faction)
                continue;

            if (Vector3.Distance(enemy.transform.position, transform.position) <= vision * GridGenerator.Instance.singleGridSize)
            {
                if (enemiesInRange.Exists(increment => increment == enemy) == false)
                    enemiesInRange.Add(enemy);
                if (enemy.structuresThatCanSeeYou.Exists(increment => increment == this) == false)
                    enemy.structuresThatCanSeeYou.Add(this);
            }
            else
            {
                enemiesInRange.Remove(enemy);
                enemy.structuresThatCanSeeYou.Remove(this);
            }
        }

        foreach (Transform child in transform.parent)
        {
            StructureBase building = child.GetComponent<StructureBase>();

            if (!building)
                continue;

            if (building.faction == faction)
                continue;

            if (Vector3.Distance(building.transform.position, transform.position) <= vision * GridGenerator.Instance.singleGridSize)
            {
                if (structuresInRange.Exists(increment => increment == building) == false)
                    structuresInRange.Add(building);
                if (building.structuresThatCanSeeYou.Exists(increment => increment == this) == false)
                    building.structuresThatCanSeeYou.Add(this);
            }
            else
            {
                structuresInRange.Remove(building);
                building.structuresThatCanSeeYou.Remove(this);
            }
        }
    }
}
