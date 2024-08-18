using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Naming : MonoBehaviour
{
    public TMP_InputField playerNameInput;
    public NetworkManager networkManager;
    private string playerName = null;

    private void Awake()
    {
        playerNameInput.onEndEdit.AddListener(OnNameInputEnd);
    }

    private void OnNameInputEnd(string name)
    {
        if (name.Length > 1 && name.Length < 20)
        {
            GameManager.instance.SettingPlayerName(name);
            playerName = name;

            Debug.Log("Player Name: " + playerName);

            networkManager.Connect();
        }
    }


}
