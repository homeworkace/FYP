using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public enum PRODUCTION_MODE
{
    NONE,
    UNITS,
    STRUCTURES,

    NUM_MODES
}

public class Spawner_Button_Stats
{
    public string name = "";
    public bool hasSpawned = false;
    public float cooldownTimer = 0.0f;
    public float activeTimerUpdater = 0.0f;
    public bool isHero = false;
    public bool isToggle = false;
    public PRODUCTION_MODE binder = PRODUCTION_MODE.NONE;

    public Spawner_Button_Stats(string val1, bool spawned, float timer, PRODUCTION_MODE mode, bool istoggle)
    {
        name = val1;
        hasSpawned = spawned;
        cooldownTimer = timer;
        activeTimerUpdater = timer;
        binder = mode;
        isToggle = istoggle;
    }
}

public class HUD_Manager : MonoBehaviour
{
    GameObject[] player_storage;
    public GameObject player_instance = null;
    GameObject[] base_storage;
    public GameObject player_base = null;
    public Button[] spawner_buttons = null;
    public List<Spawner_Button_Stats> spawner_buttons_stats = new List<Spawner_Button_Stats>();
    public Vector3 start_coordinates_points = new Vector3(431, -171, 0);
    public float xincrement = 10.0f;
    public List<GameObject> EvolvePoints = new List<GameObject>();

    public PRODUCTION_MODE currProdMode = PRODUCTION_MODE.NONE;
    public 
    void Awake()
    {
        player_storage = new GameObject[GameObject.FindGameObjectsWithTag("Player").Length];
        player_storage = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject player in player_storage)
        {
            if (player.GetComponent<PhotonView>().Owner != null)
            {
                player_instance = player;
                break;
            }
        }

        base_storage = new GameObject[GameObject.FindGameObjectsWithTag("Base").Length];
        base_storage = GameObject.FindGameObjectsWithTag("Base");

        foreach (GameObject _base in base_storage)
        {
            if (_base.GetComponent<StructureBase>().faction == player_instance.GetComponent<PlayerDetails>().faction)
            {
                player_base = _base;
                break;
            }
        }

        spawner_buttons = new Button[GameObject.Find("ProductionPanel").GetComponentsInChildren<Button>().Length];
        spawner_buttons = GameObject.Find("ProductionPanel").GetComponentsInChildren<Button>();

        foreach (Button button in spawner_buttons)
        {
            float timer = 0.0f;
            PRODUCTION_MODE mode = PRODUCTION_MODE.NONE;
            bool toggle = false;

            
            switch (button.name)
            {
                case "FootSoldier":
                    timer = 3.0f;
                    mode = PRODUCTION_MODE.UNITS;
                    button.gameObject.SetActive(false);
                    toggle = false;
                    break;
                case "Tank":
                    timer = 6.0f;
                    mode = PRODUCTION_MODE.UNITS;
                    button.gameObject.SetActive(false);
                    toggle = false;
                    break;
                case "Scout":
                    timer = 1.0f;
                    mode = PRODUCTION_MODE.UNITS;
                    button.gameObject.SetActive(false);
                    toggle = false;
                    break;
                case "Artillery":
                    timer = 7.0f;
                    mode = PRODUCTION_MODE.UNITS;
                    button.gameObject.SetActive(false);
                    toggle = false;
                    break;
                case "Sniper":
                    timer = 7.0f;
                    mode = PRODUCTION_MODE.UNITS;
                    button.gameObject.SetActive(false);
                    toggle = false;
                    break;
                case "Hero":
                    mode = PRODUCTION_MODE.UNITS;
                    button.gameObject.SetActive(false);
                    toggle = false;
                    break;
                case "Barricade":
                    timer = 4.0f;
                    mode = PRODUCTION_MODE.STRUCTURES;
                    button.gameObject.SetActive(false);
                    toggle = false;
                    break;
                case "Turret":
                    timer = 6.0f;
                    mode = PRODUCTION_MODE.STRUCTURES;
                    button.gameObject.SetActive(false);
                    toggle = false;
                    break;
                case "Harvester":
                    timer = 3.0f;
                    mode = PRODUCTION_MODE.STRUCTURES;
                    button.gameObject.SetActive(false);
                    toggle = false;
                    break;
                default:
                    button.gameObject.SetActive(true);
                    break;
            }
            spawner_buttons_stats.Add(new Spawner_Button_Stats(button.name, false, timer, mode, toggle));
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Update player instance if broken somehow
        if (!player_instance)
        {
            player_storage = null;
            player_storage = new GameObject[GameObject.FindGameObjectsWithTag("Player").Length];
            player_storage = GameObject.FindGameObjectsWithTag("Player");

            foreach (GameObject player in player_storage)
            {
                if (player.GetComponent<PhotonView>().IsMine)
                {
                    player_instance = player;
                    break;
                }
            }
        }
        else
        {
            // Update player's base location
            if (!player_base)
            {
                base_storage = null;
                base_storage = new GameObject[GameObject.FindGameObjectsWithTag("Base").Length];
                base_storage = GameObject.FindGameObjectsWithTag("Base");

                foreach (GameObject _base in base_storage)
                {
                    if (_base.GetComponent<StructureBase>().faction == player_instance.GetComponent<PlayerDetails>().faction)
                    {
                        player_base = _base;
                        break;
                    }
                }
            }

            // Handle player's HERO unit spawning
            if (EvolvePoints.Count != player_instance.GetComponent<PlayerDetails>().evolve_points)
            {
                EvolvePoints.Clear();
                for (int i = 0; i < player_instance.GetComponent<PlayerDetails>().evolve_points; i++)
                {
                    GameObject go = Instantiate(Resources.Load<GameObject>("HUD/EvolveIndicator"), GameObject.Find("Units").transform);
                    go.transform.position = new Vector3(start_coordinates_points.x + (i * xincrement), start_coordinates_points.y, 0);
                    EvolvePoints.Add(go);
                }
            }

        }


        foreach (Spawner_Button_Stats button in spawner_buttons_stats)
        {
            // Update ability for button to spawn object
            if (button.hasSpawned)
            {
                button.activeTimerUpdater -= Time.deltaTime;
                if (button.activeTimerUpdater <= 0)
                {
                    Vector3 spawnGridPos = player_base.transform.position;

                    if (button.name == "FootSoldier" || button.name == "Tank" || button.name == "Scout" || button.name == "Artillery" || button.name == "Sniper")
                    {
                        GameObject spawner = null;
                        spawner = GameManager.Instance.SpawnSoldier(button.name, spawnGridPos, player_instance.GetComponent<PlayerDetails>().faction);
                    }
                    else if (button.name == "Barricade" || button.name == "Turret" || button.name == "Harvester")
                    {
                        button.isToggle = true;
                    }

                    button.activeTimerUpdater = button.cooldownTimer;
                    button.hasSpawned = false;
                }
            }

            foreach (Button fill in spawner_buttons)
            {
                
                if (fill.name == button.name)
                {
                    // Manage cooldown indicator
                    foreach (Image children in fill.GetComponentsInChildren<Image>())
                    {
                        if (children.name == fill.name)
                            continue;

                        children.fillAmount = button.activeTimerUpdater / button.cooldownTimer;
                    }

                    if (fill.GetComponentInChildren<Text>())
                    {
                        if (fill.name == "FootSoldier" || fill.name == "Tank" || fill.name == "Scout" || fill.name == "Artillery" || fill.name == "Sniper")
                        {
                            fill.GetComponentInChildren<Text>().text = fill.name + "\n" + Resources.Load<GameObject>("Enemies/" + fill.name).GetComponent<EnemyBase>().cost;
                        }
                        else if (fill.name == "Barricade" || fill.name == "Turret" || fill.name == "Harvester")
                        {
                            fill.GetComponentInChildren<Text>().text = fill.name + "\n" + Resources.Load<GameObject>("Structures/" + fill.name).GetComponent<StructureBase>().cost;
                        }
                    }

                    // Give buttons that indicate their finished task a "light-up" feature
                    if (button.isToggle)
                    {
                        
                    }
                }
            }

        }

    }

    public void UnitSpawner(string name)
    {
    //    GameObject spawned = null;
        foreach (Spawner_Button_Stats button in spawner_buttons_stats)
        {
            if (button.name == name && !button.hasSpawned)
            {
             //   spawned = GameManager.Instance.SpawnSoldier(button.name, spawnGridPos, player_instance.GetComponent<PlayerDetails>().faction);

                if (player_instance.GetComponent<PlayerDetails>().money >= Resources.Load<GameObject>("Enemies/" + button.name).GetComponent<EnemyBase>().cost)
                {
            //        spawned.transform.position = spawnGridPos;
                    player_instance.GetComponent<PlayerDetails>().money -= Resources.Load<GameObject>("Enemies/" + button.name).GetComponent<EnemyBase>().cost;

                    button.hasSpawned = true;
                }
                else
                {
                    // Yeet it off
            //        Destroy(spawned);
                }
            }
        }

    }

    public void BuildingSpawner(string name)
    {
    //    GameObject spawned = null;
        foreach (Spawner_Button_Stats button in spawner_buttons_stats)
        {
            if (button.name == name && !button.hasSpawned && player_instance.GetComponent<PlayerDetails>().currClickState != CLICKSTATE.PLACE_MODE)
            {
                Vector3 spawnGridPos = player_base.transform.position;
                if (!button.isToggle)
                {
                    //       spawned = GameManager.Instance.SpawnBuilding(button.name, spawnGridPos,player_instance.GetComponent<PlayerDetails>().faction);

                    if (player_instance.GetComponent<PlayerDetails>().money >= Resources.Load<GameObject>("Structures/" + button.name).GetComponent<StructureBase>().cost)
                    {
                        //            player_instance.GetComponent<PlayerDetails>().buildingType = button.name;
                        //           player_instance.GetComponent<PlayerDetails>().currClickState = CLICKSTATE.PLACE_MODE;
                        player_instance.GetComponent<PlayerDetails>().money -= Resources.Load<GameObject>("Structures/" + button.name).GetComponent<StructureBase>().cost;
                        //             Destroy(spawned);
                        button.hasSpawned = true;
                    }
                    else
                    {
                        // Yeet it off
                        //           Destroy(spawned);
                    }
                }
                else
                {
                    player_instance.GetComponent<PlayerDetails>().buildingType = button.name;
                    player_instance.GetComponent<PlayerDetails>().currClickState = CLICKSTATE.PLACE_MODE;
         //           GameObject spawned = GameManager.Instance.SpawnBuilding(button.name, spawnGridPos, player_instance.GetComponent<PlayerDetails>().faction);
                    button.isToggle = false;
                }
            }
        }
    }

    public void ProductionModeSwitcher(int mode)
    {
        foreach (Spawner_Button_Stats button in spawner_buttons_stats)
        {
            foreach (Button actualButton in spawner_buttons)
            {
                if (!actualButton)
                    continue;

                if (actualButton.name != button.name)
                    continue;


                switch (mode)
                {
                    case 0:
                        if (button.binder != PRODUCTION_MODE.NONE)
                        {
                            actualButton.gameObject.SetActive(false);
                        }
                        else
                        {
                            actualButton.gameObject.SetActive(true);
                        }
                        break;
                    case 1:
                        if (button.binder == PRODUCTION_MODE.NONE)
                        {
                            actualButton.gameObject.SetActive(false);
                        }
                        else
                        {
                            if (button.binder == PRODUCTION_MODE.STRUCTURES)
                            {
                                actualButton.gameObject.SetActive(false);
                            }
                            else if (button.binder == PRODUCTION_MODE.UNITS)
                            {
                                actualButton.gameObject.SetActive(true);
                            }
                        }
                        break;
                    case 2:
                        if (button.binder == PRODUCTION_MODE.NONE)
                        {
                            actualButton.gameObject.SetActive(false);
                        }
                        else
                        {
                            if (button.binder == PRODUCTION_MODE.STRUCTURES)
                            {
                                actualButton.gameObject.SetActive(true);
                            }
                            else if (button.binder == PRODUCTION_MODE.UNITS)
                            {
                                actualButton.gameObject.SetActive(false);
                            }
                        }
                        break;
                }
            }
        }
    }

}
