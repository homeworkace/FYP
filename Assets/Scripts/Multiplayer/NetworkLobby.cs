using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class NetworkLobby : MonoBehaviourPunCallbacks
{
    public GameObject LoadingObject;
    public Text ConnectingText;

    public GameObject roomListContent;
    public GameObject roomDisplayPrefab;
    private float cellHeight;

    public Text connectionStatusText;

    public GameObject LobbyUI;
    public GameObject RoomUI;

    private Dictionary<string, RoomInfo> cachedRoomList;
    private Dictionary<string, GameObject> roomListEntries;
    private Dictionary<int, GameObject> playerListEntries;

    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        cachedRoomList = new Dictionary<string, RoomInfo>();
        roomListEntries = new Dictionary<string, GameObject>();
    }
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.OfflineMode = true;
        //PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        LoadingObject.SetActive(false);
        ConnectingText.gameObject.SetActive(false);
       // PhotonNetwork.JoinLobby();
        PhotonNetwork.LoadLevel("GameScene");
        LobbyUI.SetActive(true);
    }

    public override void OnJoinedLobby()
    {
        
    }

    public override void OnJoinedRoom()
    {
        //TESTING FOR SINGLEPLAYER
        //PhotonNetwork.LoadLevel("GameScene");
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.LoadLevel("GameScene");
        }
    }

    // Update is called once per frame
    void Update()
    {
        string connectionStatusMessage = "Connection Status: ";
        connectionStatusText.text = connectionStatusMessage + PhotonNetwork.NetworkClientState;
    }

    //ROOM LIST
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        ClearRoomListView();

        UpdateCachedRoomList(roomList);
        UpdateRoomListView();
    }

    private void ClearRoomListView()
    {
        foreach (GameObject entry in roomListEntries.Values)
        {
            Destroy(entry.gameObject);
        }

        roomListEntries.Clear();
    }

    private void UpdateCachedRoomList(List<RoomInfo> roomList)
    {
        foreach (RoomInfo info in roomList)
        {
            // Remove room from cached room list if it got closed, became invisible or was marked as removed
            if (!info.IsOpen || !info.IsVisible || info.RemovedFromList)
            {
                if (cachedRoomList.ContainsKey(info.Name))
                {
                    cachedRoomList.Remove(info.Name);
                }

                continue;
            }

            // Update cached room info
            if (cachedRoomList.ContainsKey(info.Name))
            {
                cachedRoomList[info.Name] = info;
            }
            // Add new room info to cache
            else
            {
                cachedRoomList.Add(info.Name, info);
            }
        }
    }

    private void UpdateRoomListView()
    {
        cellHeight = roomDisplayPrefab.GetComponent<RectTransform>().sizeDelta.y;
        Vector2 contentSize = roomListContent.GetComponent<RectTransform>().sizeDelta;
        contentSize.y = cellHeight * cachedRoomList.Count;
        if ((roomListContent.GetComponent<RectTransform>().sizeDelta - contentSize).y <= 0)
        {
            roomListContent.GetComponent<RectTransform>().sizeDelta = contentSize;
        }

        int increment = 1;
        foreach (RoomInfo info in cachedRoomList.Values)
        {
            GameObject newCell = Instantiate(roomDisplayPrefab,roomListContent.transform);
            newCell.GetComponent<RoomCell>().Initialize(info.Name, (byte)info.PlayerCount, info.MaxPlayers);

            roomListEntries.Add(info.Name, newCell);

            Vector3 cellPos = newCell.transform.localPosition;
            cellPos.x = 0;
            cellPos.y = roomListContent.GetComponent<RectTransform>().sizeDelta.y * 0.5f - cellHeight * 0.5f + increment * -cellHeight;
            cellPos.z = 0;
            newCell.transform.localPosition = cellPos;
            ++increment;
        }
        roomListContent.transform.localPosition = new Vector3(0, -roomListContent.GetComponent<RectTransform>().sizeDelta.y * 0.5f, 0);
    }

    public void OnClickCreateRoom()
    {
        string roomName;
        roomName = "Room " + Random.Range(1000, 10000);

        byte maxPlayers;
        maxPlayers = 2;

        RoomOptions options = new RoomOptions { MaxPlayers = maxPlayers };

        PhotonNetwork.CreateRoom(roomName, options, null);

        LobbyUI.SetActive(false);
        RoomUI.SetActive(true);
    }
    
    public void OnClickLeaveRoom()
    {
        if (PhotonNetwork.InRoom)
        {
            PhotonNetwork.LeaveRoom();
            SceneManager.LoadScene("MainMenu");
        }
    }
}
