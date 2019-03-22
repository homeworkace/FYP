using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Concede_Manager : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Switcher()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }

    public void GameExit()
    {
        PhotonNetwork.LeaveRoom();
    }
}
