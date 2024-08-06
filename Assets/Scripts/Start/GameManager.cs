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


    public void OnPlayerDead()
    {
        isGameover = true;
        gameoverUI.SetActive(true);
    }
}
