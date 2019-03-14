using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class HUD_Manager : MonoBehaviour
{
    GameObject[] player_storage;
    GameObject player_instance = new GameObject();


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
    }

    // Update is called once per frame
    void Update()
    {
        if (!player_instance)
        {
            foreach (GameObject player in player_storage)
            {
                if (player.GetComponent<PhotonView>().Owner != null)
                {
                    player_instance = player;
                    break;
                }
            }
        }
    }
}
