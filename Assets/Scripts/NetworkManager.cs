using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public Text StatusText;
    public InputField roomInput, NickNameInput;

    private void Awake() => Screen.SetResolution(1280, 720, false);

    private void Update() => StatusText.text = PhotonNetwork.NetworkClientState.ToString();
    // 네트워크 상태 표시

    public void OnConnectedToServer() => PhotonNetwork.ConnectUsingSettings();
    //서버 접속

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.LocalPlayer.NickName = NickNameInput.text;
        PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions { MaxPlayers = 5 }, null);
    }

}
