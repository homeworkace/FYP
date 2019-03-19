using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class GameManager : MonoBehaviourPunCallbacks
{
    public static GameManager Instance;
    // Start is called before the first frame update
    public bool gameStart = false;
    public GameObject basePrefab;
    public GameObject basicTowerPrefab;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
    }

    public GameObject SpawnEnvironment(Vector3 pos, Quaternion rotation)
    {
        return PhotonNetwork.Instantiate("Environment", pos, rotation, 0);
    }

    // Update is called once per frame
    void Update()
    {
        CheckGameStart();
    }

    void CheckGameStart()
    {
        if (gameStart == false)
        {
            if (PhotonNetwork.OfflineMode == false)
            {
                var bases = GameObject.FindGameObjectsWithTag("Base");
                if (bases.Length == PhotonNetwork.PlayerList.Length)
                    gameStart = true;
            }
            else
            {
                var bases = GameObject.FindGameObjectsWithTag("Base");
                if (bases.Length == 1)
                    gameStart = true;
            }
        }
    }

    public GameObject SpawnSoldier(Vector3 hitInfoPos, FACTION fac)
    {
        return PhotonNetwork.Instantiate("FootSoldier", hitInfoPos, Quaternion.identity, 0);   
    }
    public void SpawnPlayer()
    {
        GameObject player = PhotonNetwork.Instantiate("Player", Vector3.zero, Quaternion.identity, 0);
    }
    public GameObject SpawnBuilding(string buildingName,Vector3 spawnInfoPos)
    {
        return PhotonNetwork.Instantiate(buildingName, spawnInfoPos, Quaternion.identity, 0);
    }
}
