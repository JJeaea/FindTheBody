using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    private void Awake() => Screen.SetResolution(1280, 720, false);

    public void Connect()
    {
        Debug.Log("Trying to connect to Photon server...");
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("PhotonNetwork state after ConnectUsingSettings: " + PhotonNetwork.NetworkClientState);
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("���� ���� �Ϸ�");

        // GameManager���� ����� �̸��� ������
        string playerName = GameManager.instance.OutputPlayerName();
        PhotonNetwork.LocalPlayer.NickName = playerName;

        PhotonNetwork.JoinLobby();

    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        print(System.Reflection.MethodBase.GetCurrentMethod().Name);
        SceneManager.LoadScene("LobbyScene");
    }


    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.LogError("Disconnected from Photon server: " + cause);
    }
}