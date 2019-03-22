using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class Energy_Display_Manager : MonoBehaviour
{
    public GameObject[] player_storage;
    public GameObject player_instance;

    public Text energy_text_display;

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

        energy_text_display = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!player_instance)
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
        else
        {
            if (energy_text_display)
            {
                energy_text_display.text = player_instance.GetComponent<PlayerDetails>().money.ToString() + "\n(" + (player_instance.GetComponent<PlayerDetails>().harvestAmount).ToString() + ")";
            }
            else
            {
                energy_text_display = GetComponentInChildren<Text>();
            }
        }
    }
}
