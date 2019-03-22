using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class Unit_Selection_Manager : MonoBehaviour
{
    public GameObject player_instance;
    public GameObject[] player_storage = null;
    public GameObject unit_indicator = null;
    public Button[] indicator_buttons = null;

    // Start is called before the first frame update
    void Start()
    {
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

    // Update is called once per frame
    void Update()
    {
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
            if (!unit_indicator)
            {
                if (player_instance.GetComponent<PlayerDetails>().selectedUnits.Count > 0)
                {

                    Vector3 totalPos = new Vector3();

                    foreach (EnemyBase unit in player_instance.GetComponent<PlayerDetails>().selectedUnits)
                    {
                        if (!unit)
                            continue;

                        totalPos += unit.transform.position;
                    }

                    totalPos /= player_instance.GetComponent<PlayerDetails>().selectedUnits.Count;

                    unit_indicator = Instantiate(Resources.Load<GameObject>("HUD/UnitIndicator"), transform);
                    unit_indicator.transform.position = Camera.main.WorldToScreenPoint(totalPos) + new Vector3(0, 40, -Camera.main.WorldToScreenPoint(totalPos).z);

                        indicator_buttons = null;
                        indicator_buttons = new Button[GetComponentsInChildren<Button>().Length];
                        indicator_buttons = GetComponentsInChildren<Button>();

                        foreach (Button button in indicator_buttons)
                        {
                            switch (button.name)
                            {
                                case "Aggressive":
                                    button.onClick.AddListener(delegate { ChangeStrat(STRATEGY.ATTACK); });
                                    break;
                                case "Passive":
                                    button.onClick.AddListener(delegate { ChangeStrat(STRATEGY.PASSIVE); });
                                    break;
                            }
                        }
                    
                }
            }
            else
            {


                if (player_instance.GetComponent<PlayerDetails>().selectedUnits.Count > 0)
                {
                    Vector3 totalPos = new Vector3();

                    foreach (EnemyBase unit in player_instance.GetComponent<PlayerDetails>().selectedUnits)
                    {
                        if (!unit)
                            continue;

                        totalPos += unit.transform.position;
                    }

                    totalPos /= player_instance.GetComponent<PlayerDetails>().selectedUnits.Count;
                    unit_indicator.transform.position = (Camera.main.WorldToScreenPoint(totalPos)) + new Vector3(0, 40, -Camera.main.WorldToScreenPoint(totalPos).z);
                }
                else
                {
                    Destroy(unit_indicator);
                    unit_indicator = null;
                }
            }
        }
    }

    public void ChangeStrat(STRATEGY strat)
    {
       
        if (player_instance)
        {
            if (player_instance.GetComponent<PlayerDetails>().selectedUnits.Count > 0)
            {
                foreach (EnemyBase unit in player_instance.GetComponent<PlayerDetails>().selectedUnits)
                {
                    if (!unit)
                        continue;

                    unit.strategy = strat;
                    Debug.Log(unit.strategy);
                }
            }
        }
    }
}
