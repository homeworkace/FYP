using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public int tileID = -1;
    private Material originalMaterial;
    public List<EnemyBase> enemies = new List<EnemyBase>();
    public List<StructureBase> buildings = new List<StructureBase>();
    public Vector3 tilePos;

    public void Start()
    {
        originalMaterial = GetComponent<Renderer>().material;
    }

    public void Update()
    {
        if (enemies.Count > 0)
        {
            GetComponent<Renderer>().material = null;
        }
        else
        {
            GetComponent<Renderer>().material = originalMaterial;
        }
    }
    
    public bool IsTileOccupied()
    {
        if (buildings.Count > 0)
            return true;
        return false;
    }

    public void AddEnemy(EnemyBase enemy)
    {
        enemies.Add(enemy);
    }

    public void RemoveEnemy(EnemyBase enemy)
    {
        enemies.Remove(enemy);
    }

    public void AddBuilding(StructureBase building)
    {
        buildings.Add(building);
    }

    public void RemoveBuilding(StructureBase building)
    {
        buildings.Remove(building);
    }
}
