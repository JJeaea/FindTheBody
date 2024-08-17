using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LobbyNetwork : MonoBehaviourPunCallbacks
{

    public void CreateRoom()
    {
        string roomName = GameManager.instance.OutputRoomName();

        RoomOptions ro = new RoomOptions();
        ro.MaxPlayers = 7;
        ro.IsOpen = true;
        ro.IsVisible = true;

        PhotonNetwork.CreateRoom(roomName, new RoomOptions { MaxPlayers = 7 });
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("���� ���������� �����Ǿ����ϴ�.");
        SceneManager.LoadScene("SelectScene");
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.LogError("�� ������ �����߽��ϴ�: " + message);
    }

    public Transform scrollContent;  // Scroll View�� Content ������Ʈ
    public GameObject roomPrefab;    // �������� ������ Room ������
    private Dictionary<string, GameObject> roomDict = new Dictionary<string, GameObject>();

    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.NickName = GameManager.instance.OutputPlayerName();

        Debug.Log(PhotonNetwork.SendRate);

        roomPrefab = Resources.Load<GameObject>("Info");

        if (!PhotonNetwork.IsConnected)
        {
            PhotonNetwork.ConnectUsingSettings();
        }

        Debug.Log("Photon Network Status: " + PhotonNetwork.NetworkClientState);
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        Debug.Log("Room list updated. Room count: " + roomList.Count);

        foreach (var room in roomList)
        {
            Debug.Log("Processing room: " + room.Name);

            if (room.RemovedFromList)
            {
                if (roomDict.TryGetValue(room.Name, out GameObject tempRoom))
                {
                    Destroy(tempRoom);
                    roomDict.Remove(room.Name);
                }
            }
            else
            {
                if (!roomDict.ContainsKey(room.Name))
                {
                    GameObject roomEntry = Instantiate(roomPrefab, scrollContent);
                    RoomList roomListComponent = roomEntry.GetComponent<RoomList>();
                    roomListComponent.RoomInfo = room;
                    roomDict.Add(room.Name, roomEntry);
                }
                else
                {
                    if (roomDict.TryGetValue(room.Name, out GameObject tempRoom))
                    {
                        tempRoom.GetComponent<RoomList>().RoomInfo = room;
                    }
                }
            }
        }
    }
}
