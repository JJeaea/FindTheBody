using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NickName : MonoBehaviour
{
    public TMP_Text playerNameText;

    private void Start()
    {
        playerNameText.text = GameManager.instance.OutputPlayerName();
        Debug.Log(GameManager.instance.OutputPlayerName());
        print("����ƴ���? : " + PhotonNetwork.IsConnected);
    }
}
