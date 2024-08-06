using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Naming : MonoBehaviour
{
    public InputField playerNameInput;
    private string playerName = null;

    private void Awake()
    {
        playerName = playerNameInput.GetComponent<InputField>().text;
    }

    private void Update()
    {
        if(playerName.Length > 1 && playerName.Length <11)
        {
            playerName = playerNameInput.text;
            GameManager.instance.SettingPlayerName(playerName);
        }
    }

    
}
