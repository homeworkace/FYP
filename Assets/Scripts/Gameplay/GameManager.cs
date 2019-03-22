using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class GameManager : MonoBehaviourPunCallbacks
{
    public static GameManager Instance;
    // Start is called before the first frame update
    public bool gameStart = false;
    private bool gameEnd = false;
    public GameObject basePrefab;
    public GameObject barricadePrefab;
    public GameObject turretPrefab;
    public GameObject harversterPrefab;
    public Text gameOverText;

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
        if (gameEnd == true)
            return;

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
                {
                    GameObject terrain = GameObject.Find("Terrain");
                    RaycastHit hitInfo;
                    int layer = (1 << LayerMask.NameToLayer("Terrain"));
                    Physics.Raycast(terrain.transform.position + Vector3.up * 10000 + Vector3.forward * 160, Vector3.down, out hitInfo,float.MaxValue,layer);
                    SpawnBuilding("Base", hitInfo.point, FACTION.ORANGE);
                    gameStart = true;
                }
            }
        }
        else
        {
        var bases = GameObject.FindGameObjectsWithTag("Base");
            if (PhotonNetwork.OfflineMode == false)
            {
                if (bases.Length < 2)
                {
                    gameStart = false;
                    gameEnd = true;
                    if (bases.Length > 0)
                    {
                        gameOverText.gameObject.SetActive(true);
                        if (bases[0].GetPhotonView().IsMine)
                            gameOverText.text = "You Win!";
                        else
                            gameOverText.text = "You Lose!";
                    }
                }
            }
            else
            {
                if (bases.Length < 2)
                {
                    gameStart = false;
                    gameEnd = true;
                    if (bases.Length > 0)
                    {
                        gameOverText.gameObject.SetActive(true);
                        if (bases[0].GetComponent<StructureBase>().faction == FACTION.BLUE)
                            gameOverText.text = "You Win!";
                        else
                            gameOverText.text = "You Lose!";
                    }
                }
            }
        }
    }

    public GameObject SpawnSoldier(string soldierName, Vector3 position,FACTION fac)
    {
        object[] instanceData = new object[1];
        instanceData[0] = fac;

        return PhotonNetwork.Instantiate("Enemies/" + soldierName, position + new Vector3(0, 1, 0), Quaternion.identity, 0,instanceData);
    }
    public void SpawnPlayer(FACTION fac)
    {
        object[] instanceData = new object[1];
        instanceData[0] = fac;

        GameObject player = PhotonNetwork.Instantiate("Player", Vector3.zero, Quaternion.identity, 0,instanceData);
    }
    public GameObject SpawnBuilding(string buildingName,Vector3 spawnInfoPos,FACTION fac)
    {
        object[] instanceData = new object[1];
        instanceData[0] = fac;

        return PhotonNetwork.Instantiate("Structures/" + buildingName, spawnInfoPos, Quaternion.identity, 0,instanceData);
    }
    public GameObject SpawnProjectile(string projectileName,Vector3 spawnPos, int targetEnemyViewID, int damage,float speed,FACTION fac)
    {
        object[] instanceData = new object[4];
        instanceData[0] = damage;
        instanceData[1] = speed;
        instanceData[2] = targetEnemyViewID;
        instanceData[3] = fac;
        return PhotonNetwork.Instantiate("Gameplay/Projectiles/" + projectileName, spawnPos, Quaternion.identity, 0, instanceData);
    }
}
