using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour {

    public static GridGenerator Instance;
    public GameObject tilePrefab;
    public int xGridAmount, zGridAmount;
    public float singleGridSize;
    public List<Tile> grid;
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
        grid = new List<Tile>();
        for (int i = 0;i<xGridAmount*zGridAmount;++i)
        {
            GameObject tileGO = Instantiate(tilePrefab, gridsInEnvironment);
            Vector3 tileScale = tileGO.transform.localScale;
            tileScale.Set(singleGridSize, 0.05f, singleGridSize);
            tileGO.transform.localScale = tileScale;
            tileGO.transform.localPosition = GridIDToLocalPosition(i);
            tileGO.GetComponent<Tile>().tileID = i;
            tileGO.GetComponent<Tile>().tilePos = tileGO.transform.position;
            grid.Add(tileGO.GetComponent<Tile>());
        }
    }
	
	// Update is called once per frame
	void Update () {
        CalculateEnemiesOnGrid();
        CalculateStructuresOnGrid();
	}

    void CalculateEnemiesOnGrid()
    {
        foreach (Transform enemyTransform in enemiesInEnvironment)
        {
            EnemyBase enemy = enemyTransform.GetComponent<EnemyBase>();

            RaycastHit hitInfo;
            Physics.Raycast(enemy.transform.position, Vector3.down, out hitInfo, Mathf.Infinity, LayerMask.GetMask("Tile"));
            int currentEnemyGridID = -1;
            if (hitInfo.transform != null)
            currentEnemyGridID = hitInfo.transform.gameObject.GetComponent<Tile>().tileID;
            if (enemy.gridID == -1)
            {
                enemy.gridID = currentEnemyGridID;
                if (currentEnemyGridID == -1)
                    continue;
                grid[enemy.gridID].AddEnemy(enemy);
            }
            else if (enemy.gridID != currentEnemyGridID)
            {
                grid[enemy.gridID].RemoveEnemy(enemy);
                enemy.gridID = currentEnemyGridID;
                if (currentEnemyGridID == -1)
                    continue;
                grid[enemy.gridID].AddEnemy(enemy);
            }
        }
    }

    void CalculateStructuresOnGrid()
    {
        foreach (Transform structureTransform in buildingsInEnvironment)
        {
            StructureBase structure = structureTransform.GetComponent<StructureBase>();

            RaycastHit hitInfo;
            Physics.Raycast(structure.transform.position + new Vector3(0,10,0), Vector3.down, out hitInfo, Mathf.Infinity, LayerMask.GetMask("Tile"));
            int currentStructureGridID = hitInfo.transform.gameObject.GetComponent<Tile>().tileID;
            if (structure.gridID == -1)
            {
                structure.gridID = currentStructureGridID;
                if (currentStructureGridID == -1)
                    continue;
                grid[structure.gridID].AddBuilding(structure);
            }
            else if (structure.gridID != currentStructureGridID)
            {
                grid[structure.gridID].RemoveBuilding(structure);
                structure.gridID = currentStructureGridID;
                if (currentStructureGridID == -1)
                    continue;
                grid[structure.gridID].AddBuilding(structure);
            }
        }
    }

    public Vector3 GridIDToPosition(int gridID)
    {
        return grid[gridID].tilePos;
    }

    public Vector3 GridIDToLocalPosition(int gridID)
    {
        Vector3 gridLocalPos = Vector3.zero;
        int xGrids = gridID % xGridAmount;
        int zGrids = gridID / xGridAmount;

        gridLocalPos.x = xGrids * singleGridSize;
        gridLocalPos.z = zGrids * singleGridSize;
        return gridLocalPos;
    }

    public Vector3 GridIDToGridPos(int gridID)
    {
        Vector3 gridPos = Vector3.zero;
        int xGrids = gridID % xGridAmount;
        int zGrids = gridID / xGridAmount;

        gridPos.x = xGrids;
        gridPos.z = zGrids;
        return gridPos;
    }

    public Vector3 GridPosToPosition(Vector3 gridPos)
    {
        return grid[GridPosToGridID(gridPos)].tilePos;
    }

    public Vector3 PositionToGridPos(Vector3 pos)
    {
        RaycastHit hitInfo;
        Physics.Raycast(pos, Vector3.down, out hitInfo, Mathf.Infinity, LayerMask.GetMask("Tile"));
        if (hitInfo.transform != null)
        {
            pos = hitInfo.transform.localPosition;
        }
        else
        {
            Debug.Log("Hit Info Is NULL");
            return pos;
        }

        pos.x += singleGridSize * 0.5f;
        pos.z += singleGridSize * 0.5f;
        int xGridPos = (int)(pos.x / singleGridSize);
        int zGridPos = (int)(pos.z / singleGridSize);

        pos.x = xGridPos;
        pos.y = 0;
        pos.z = zGridPos;
        return pos;
    }

    public int GridPosToGridID(Vector3 pos)
    {
        return ((int)(pos.x + (pos.z * xGridAmount)));
    }

    public int PositionToGridID(Vector3 pos)
    {
        RaycastHit hitInfo;
        Physics.Raycast(pos + new Vector3(0,1,0), Vector3.down, out hitInfo, Mathf.Infinity, LayerMask.GetMask("Tile"));
        if (hitInfo.transform != null)
            return hitInfo.transform.GetComponent<Tile>().tileID;
        return -1;
    }

    public bool CalculateRoute(GameObject go, Vector3 endGridPos)
    {
        EnemyBase enemy = go.GetComponent<EnemyBase>();

        enemy.gridPos = PositionToGridPos(enemy.transform.position);

        if (enemy.gridPos.x < 0 || enemy.gridPos.x >= xGridAmount || enemy.gridPos.z < 0 || enemy.gridPos.z >= zGridAmount)
            return false;

        List<Vector3> stack = new List<Vector3>();
        List<Vector3> previous = new List<Vector3>();
        List<bool> visited = new List<bool>();


        for (int i = 0; i < xGridAmount * zGridAmount; ++i)
        {
            visited.Add(false);
        }
        for (int i = 0; i < xGridAmount * zGridAmount; ++i)
        {
            previous.Add(new Vector3());
        }

        List<float> gScore = new List<float>();
        for (int i = 0; i < xGridAmount * zGridAmount; ++i)
        {
            gScore.Add(float.MaxValue);
        }


        gScore[GridPosToGridID(enemy.gridPos)] = 0;
        

        List<float> fScore = new List<float>();
        for (int i = 0; i < xGridAmount * zGridAmount; ++i)
        {
            fScore.Add(float.MaxValue);
        }

        fScore[GridPosToGridID(enemy.gridPos)] = (endGridPos - enemy.gridPos).magnitude;

        stack.Add(enemy.gridPos);
        Vector3 curr = enemy.gridPos;

        while (stack.Count != 0)
        {
            float lowestFScore = float.MaxValue;
            int stackIndex = 0;
            for (int i = 0; i < stack.Count; ++i)
            {
                Vector3 stackItem = stack[i];
                if (fScore[GridPosToGridID(stackItem)] < lowestFScore)
                {
                    lowestFScore = fScore[GridPosToGridID(stackItem)];
                    stackIndex = i;
                }
            }

            curr = stack[stackIndex];

            if (curr == endGridPos)
            {
                enemy.path.Clear();
                while (curr != enemy.gridPos)
                {
                    enemy.path.Add(GridPosToGridID(curr));
                    curr = previous[GridPosToGridID(curr)];
                }
                return true;
            }

            stack.RemoveAt(stackIndex);
            visited[GridPosToGridID(curr)] = true;

            for (int dir = 0; dir < 4; ++dir)
            {
                Vector3 checkNext = curr;
                switch (dir)
                {
                    case 0:
                        checkNext.x += 1;
                        break;
                    case 1:
                        checkNext.x -= 1;
                        break;
                    case 2:
                        checkNext.z += 1;
                        break;
                    case 3:
                        checkNext.z -= 1;
                        break;
                    default:
                        Debug.Log("GridGeneratorPathfinding");
                        break;
                }

                if (checkNext.x < 0 || checkNext.x >= xGridAmount || checkNext.z < 0 || checkNext.z >= zGridAmount)
                    continue;

                //Check if the tiles are walkable on
                if (grid[GridPosToGridID(checkNext)].IsTileOccupied() == true)
                    continue;

                float tileCost = Vector3.Distance(GridPosToPosition(checkNext), GridPosToPosition(curr));

                if (visited[GridPosToGridID(checkNext)] == false)
                {
                    float nextGScore = gScore[GridPosToGridID(curr)] + tileCost;

                    bool inStack = false;
                    for (int i = 0; i < stack.Count; ++i)
                    {
                        if (stack[i] == checkNext)
                            inStack = true;
                    }
                    if (inStack == false)
                        stack.Add(checkNext);
                    else if (nextGScore >= gScore[GridPosToGridID(checkNext)])
                        continue;

                    previous[GridPosToGridID(checkNext)] = curr;
                    gScore[GridPosToGridID(checkNext)] = nextGScore;
                    fScore[GridPosToGridID(checkNext)] = gScore[GridPosToGridID(checkNext)] + (endGridPos - checkNext).magnitude;
                }

            }
        }
        return false;
    }
}