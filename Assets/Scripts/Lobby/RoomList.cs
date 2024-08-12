using UnityEngine;
using TMPro;
using Photon.Realtime;
using Photon.Pun;

public class RoomList : MonoBehaviour
{
    public TMP_Text RoomInfoText;
    public TMP_Text PlayerCountText;
    private RoomInfo _roomInfo;
    private LobbyNetwork lobby;

    public RoomInfo RoomInfo
    {
        get { return _roomInfo; }
        set
        {
            _roomInfo = value;
            RoomInfoText.text = $"{_roomInfo.Name}";
            PlayerCountText.text = $"{_roomInfo.PlayerCount}/{_roomInfo.MaxPlayers}";
            GetComponent<UnityEngine.UI.Button>().onClick.RemoveAllListeners();
            GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => OnEnterRoom(_roomInfo.Name));
        }
    }

    private void OnEnterRoom(string roomName)
    {
        PhotonNetwork.NickName = GameManager.instance.OutputPlayerName();

        RoomOptions ro = new RoomOptions();
        ro.MaxPlayers = 7;
        ro.IsOpen = true;
        ro.IsVisible = true;

        PhotonNetwork.JoinOrCreateRoom(roomName, ro, TypedLobby.Default);
    }
}

