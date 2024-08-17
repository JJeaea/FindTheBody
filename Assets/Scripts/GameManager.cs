using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isGameover = false;
    public GameObject gameoverUI;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
      
        else
        {
            Destroy(this.gameObject);
        }
    }

    private string playerName;

    public void SettingPlayerName(string Name)
    {
        playerName = Name;
    }

    public string OutputPlayerName()
    {
        return playerName;
    }

    private string roomName;

    public void SettingRoomName(string Name)
    {
        roomName = Name;
    }

    public string OutputRoomName()
    {
        return roomName;
    }

    // select

    private Dictionary<string, string> playerRoles = new Dictionary<string, string>(); // 플레이어 이름과 역할 저장

    public void SetPlayerRole(string playerName, string role)
    {
        if (playerRoles.ContainsKey(playerName))
        {
            playerRoles[playerName] = role;
        }
        else
        {
            playerRoles.Add(playerName, role);
        }
    }

    public string GetPlayerRole(string playerName)
    {
        return playerRoles.ContainsKey(playerName) ? playerRoles[playerName] : null;
    }

    public string GetMyRole()
    {
        string playerName = OutputPlayerName();
        return GetPlayerRole(playerName);
    }


    public void OnPlayerDead()
    {
        isGameover = true;
        gameoverUI.SetActive(true);
    }
}
