using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.EventSystems;
using Photon.Realtime;
using UnityEngine.UI;
using UnityEngine.AI;

public enum FACTION
{
    BLUE,
    ORANGE,
    NEUTRAL
}

public enum CLICKSTATE
{
    UNITCONTROL_MODE,
    PLACE_MODE,

    NUM_CLICK_STATES
}

public class PlayerDetails : MonoBehaviour
{
    [Header("Player Detail Variables")]
    public FACTION faction;
    public CLICKSTATE currClickState;
    public int money;
    public int evolve_points;
    Transform enemiesInEnvironment;
    Transform buildingsInEnvironment;
    PhotonView view;
    public List<EnemyBase> selectedUnits;

    [Header("Drag Variables")]
    public GUIStyle mouseDragSkin;
    public float clickDragZone = 1.3f;

    private Vector3 mouseDownPoint;
    private Vector3 mouseUpPoint;
    private Vector3 currentMousePoint;

    private bool isDragging;
    private bool mouseDown = false;

    private float boxWidth, boxHeight, boxLeft, boxTop;
    private Vector3 boxStart, boxFinish;
    private GameObject towerGhost = null;
    private RaycastHit towerGhostHitInfo;
    private EventSystem es;

    public Material canPlaceMaterial;
    public Material cannotPlaceMaterial;
    private bool spawnedBase = false;

    public string buildingType = "";

    private float resourceHarverstTimer = 0;
    public int harvestAmount = 0;

    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
        object[] data = view.InstantiationData;
        faction = (FACTION)data[0];

        es = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        currClickState = CLICKSTATE.UNITCONTROL_MODE;
        money = 1000;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemiesInEnvironment == null || buildingsInEnvironment == null)
        {
            if (GameObject.Find("Environment") == null)
                return;
            enemiesInEnvironment = GameObject.Find("Environment").transform.Find("Enemies");
            buildingsInEnvironment = GameObject.Find("Environment").transform.Find("Structures");
            return;
        }
        
        if (view.IsMine && GameManager.Instance.gameStart == false && spawnedBase == false)
        {
            if (SpawnGhostStructure(GameManager.Instance.basePrefab))
            {
                Vector3 finalPos = towerGhostHitInfo.point;
                finalPos.y += GameManager.Instance.basePrefab.transform.localScale.y * 0.5f;
                GameManager.Instance.SpawnBuilding("Base",GridGenerator.Instance.PositionSnapToGrid(finalPos),faction);
                spawnedBase = true;
            }
        }

        if (view.IsMine && GameManager.Instance.gameStart)
        {
            switch (currClickState)
            {
                case CLICKSTATE.UNITCONTROL_MODE:
                    
{
                        // Move 
                        if (Input.GetKeyUp(KeyCode.Mouse0) && selectedUnits.Count > 0)
                        {
                            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                            RaycastHit hitInfo;
                        //    Physics.Raycast(ray, out hitInfo);

                            if (Physics.Raycast(ray, out hitInfo))
                            {
                                if (!es.IsPointerOverGameObject())
                                {
                                    EnemyBase leaderEnemy = null;
                                    float lowestCost = float.MaxValue;
                                    NavMeshPath path;

                                    foreach (EnemyBase enemy in selectedUnits)
                                    {
                                        if (!enemy)
                                            continue;
                                        if (hitInfo.transform.GetComponent<EntityBase>() && hitInfo.transform.GetComponent<EntityBase>().faction != faction)
                                        {
                                            enemy.targetEntity = hitInfo.transform.GetComponent<EntityBase>();
                                            enemy.agent.SetDestination(enemy.targetEntity.transform.position);
                                            enemy.agent.isStopped = false;
                                        }
                                        else
                                        {
                                            path = new NavMeshPath();
                                            enemy.agent.CalculatePath(hitInfo.point, path);
                                            if (path.status != NavMeshPathStatus.PathInvalid)
                                            {
                                                enemy.agent.SetDestination(hitInfo.point);
                                                enemy.agent.isStopped = false;
                                                if (enemy.agent.remainingDistance < lowestCost)
                                                {
                                                    lowestCost = enemy.agent.remainingDistance;
                                                    leaderEnemy = enemy;
                                                }
                                            }
                                            enemy.targetEntity = null;
                                        }
                                    }
                                    Debug.Log(leaderEnemy);

                                    Debug.Log("Find Path");
                                }
                            }
                            else
                            {
                                if (!es.IsPointerOverGameObject())
                                    DeleteSelectedEnemies();
                            }
                            
                        }
                        // Select
                        if (selectedUnits.Count <= 0)
                            DraggingUpdate();
                    }
                    break;
                case CLICKSTATE.PLACE_MODE:
                    {
                        GameObject towerPrefab = null;
                        switch (buildingType)
                        {
                            case "Barricade":
                                towerPrefab = GameManager.Instance.barricadePrefab;
                                break;
                            case "Harvester":
                                towerPrefab = GameManager.Instance.harversterPrefab;
                                break;
                            case "Turret":
                                towerPrefab = GameManager.Instance.turretPrefab;
                                break;
                        }
                        // Place State
                        if (SpawnGhostStructure(towerPrefab))
                        {
                            if (Input.GetKeyUp(KeyCode.Mouse0) && !es.IsPointerOverGameObject())
                            {
                                Vector3 finalPos = towerGhostHitInfo.point;
                                finalPos.y += towerPrefab.transform.localScale.y * 0.5f;
                                GameManager.Instance.SpawnBuilding(buildingType,GridGenerator.Instance.PositionSnapToGrid(finalPos),faction);
                                currClickState = CLICKSTATE.UNITCONTROL_MODE;
                            }
                        }
                    }
                    break;
            }
            UpdateResources();
        }       
    }

    void UpdateResources()
    {
        int harvesters = 0;
        foreach (GameObject harvester in GameObject.FindGameObjectsWithTag("Structure"))
        {
            if (harvester.GetComponent<StructureBase>().faction != faction)
                continue;

            if (harvester.GetComponent<StructureBase>().type != STRUCTURE_TYPE.HARVESTER)
                continue;

            harvesters += 1;
        }

        resourceHarverstTimer += Time.deltaTime;
        if (resourceHarverstTimer >= 1.0f)
        {
            harvestAmount = 5 + (harvesters * 10);
            money += harvestAmount;
            resourceHarverstTimer = 0;
        }
    }

    //DRAGGING
    void DraggingUpdate()
    {
        currentMousePoint = Input.mousePosition;
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            mouseDown = true;
            mouseDownPoint = currentMousePoint;
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            mouseDown = false;
            mouseUpPoint = currentMousePoint;
            BoxValues();
            FindEnemiesInDrag();
            if (isDragging == true)
            {
                isDragging = false;
            }
        }
        if (Input.GetKey(KeyCode.Mouse0) && mouseDown == true)
        {
            if (Vector3.Distance(mouseDownPoint, currentMousePoint) > clickDragZone)
            {
                BoxValues();
                isDragging = true;
            }
        }
    }

    void BoxValues()
    {
        boxWidth = (mouseDownPoint - currentMousePoint).x;
        boxHeight = (mouseDownPoint - currentMousePoint).y;
        boxLeft = Input.mousePosition.x;
        boxTop = (Screen.height - Input.mousePosition.y) - boxHeight;
        if (boxWidth > 0f && boxHeight < 0f)
        {
            //Top LEFt
            boxStart = currentMousePoint;
        }
        else if (boxWidth > 0f && boxHeight > 0f)
        {
            //BOTTOM LEFT
            boxStart = currentMousePoint;
            boxStart.y += boxHeight;
        }
        else if (boxWidth < 0f && boxHeight < 0f)
        {
            //TOP RIGHT
            boxStart = currentMousePoint;
            boxStart.x += boxWidth;
        }
        else if (boxWidth < 0f && boxHeight > 0f)
        {
            //Bottom right
            boxStart = currentMousePoint;
            boxStart.x += boxWidth;
            boxStart.y += boxHeight;
        }

        float tempWidth = boxWidth, tempHeight = boxHeight;
        boxFinish = boxStart;
        if (tempWidth < 0)
            tempWidth *= -1;
        if (tempHeight < 0)
            tempHeight *= -1;
        boxFinish.x += tempWidth;
        boxFinish.y -= tempHeight;
    }

    void FindEnemiesInDrag()
    {
        Debug.Log("FIND ENEMIES IN DRAG IS RUN");

        if (selectedUnits.Count > 0)
            DeleteSelectedEnemies();

        foreach (Transform enemyTransform in enemiesInEnvironment)
        {
            EnemyBase enemy = enemyTransform.GetComponent<EnemyBase>();
            Vector3 enemyScreenPos = Camera.main.WorldToScreenPoint(enemy.transform.position);
            if (enemyScreenPos.x >= boxStart.x && enemyScreenPos.x <= boxFinish.x && enemyScreenPos.y <= boxStart.y && enemyScreenPos.y >= boxFinish.y && enemy.faction == faction)
            {
                Debug.Log("Added");
                if (selectedUnits.Find(increment => increment == enemy) != true)
                selectedUnits.Add(enemy);
            }
        }
    }

    void DeleteSelectedEnemies()
    {
        selectedUnits.Clear();
    }

    private void OnGUI()
    {
        if (isDragging)
        {
            GUI.Box(new Rect(boxLeft, boxTop, boxWidth, boxHeight), "", mouseDragSkin);
        }
    }
    //DRAGGING
    public bool SpawnGhostStructure(GameObject prefab)
    {
        int layer = (1 << LayerMask.NameToLayer("Terrain"));
        Vector3 halfPrefabHeight = Vector3.zero;
        halfPrefabHeight.y = prefab.transform.localScale.y * 0.5f;
        if (towerGhost == null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            Physics.Raycast(ray, out towerGhostHitInfo, Mathf.Infinity,layer);
            if (towerGhostHitInfo.transform != null)
            {
                towerGhost = Instantiate(prefab, towerGhostHitInfo.point + halfPrefabHeight, Quaternion.identity, GameObject.Find("Environment").transform.Find("GhostStructures"));
                towerGhost.tag = "Untagged";
                towerGhost.layer = 2;
                towerGhost.GetComponent<Collider>().isTrigger = true;
                Destroy(towerGhost.GetComponent<StructureBase>());
                Destroy(towerGhost.GetComponent<NavMeshObstacle>());
            }
        }
        else
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out towerGhostHitInfo, Mathf.Infinity, layer);
            if (towerGhostHitInfo.transform != null)
            {
                towerGhost.transform.position = towerGhostHitInfo.point + halfPrefabHeight;
                towerGhost.transform.position = GridGenerator.Instance.PositionSnapToGrid(towerGhost.transform.position);
                var collisions = Physics.OverlapBox(towerGhost.transform.position, towerGhost.GetComponent<Collider>().bounds.extents*0.5f);
                List<Collider> actualCollisions = new List<Collider>();
                foreach(Collider collider in collisions)
                {
                    if (collider.gameObject.layer != LayerMask.NameToLayer("Terrain") && collider != towerGhost.GetComponent<Collider>())
                    {
                        actualCollisions.Add(collider);
                    }
                }

                if (actualCollisions.Count <= 0)
                {
                    towerGhost.GetComponent<Renderer>().material = canPlaceMaterial;
                    if (Input.GetKeyUp(KeyCode.Mouse0))
                    {
                        Destroy(towerGhost);
                        return true;
                    }
                }
                else
                {
                    towerGhost.GetComponent<Renderer>().material = cannotPlaceMaterial;
                }
            }
            else
            {
                towerGhost.GetComponent<Renderer>().material = cannotPlaceMaterial;
            }
        }
        return false;
    }
}
