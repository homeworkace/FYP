using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour {

    public static GridGenerator Instance;
    public float singleGridSize;
    Transform enemiesInEnvironment;
    Transform gridsInEnvironment;
    Transform buildingsInEnvironment;

    // Use this for initialization
    private void Awake()
    {
        Instance = this;
    }

    void Start () {
        enemiesInEnvironment = transform.Find("Enemies");
        gridsInEnvironment = transform.Find("Grid");
        buildingsInEnvironment = transform.Find("Structures");
    }
	
	// Update is called once per frame
	void Update () {
	}

    void CalculateEnemiesOnGrid()
    {
    }

    void CalculateStructuresOnGrid()
    {
    }

    public Vector3 PositionSnapToGrid(Vector3 pos)
    {
        Vector3 snapPos = pos;
        snapPos.x += singleGridSize * 0.5f;
        snapPos.z += singleGridSize*0.5f;
        int xGrid = (int)(snapPos.x / singleGridSize);
        int zGrid = (int)(snapPos.z / singleGridSize);
        snapPos.x = xGrid * singleGridSize - singleGridSize * 0.5f;
        snapPos.z = zGrid * singleGridSize - singleGridSize*0.5f;
        return snapPos;
    }
}