using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneChange_L : MonoBehaviour
{
    public void SceneChange()
    {
        SceneManager.LoadScene("LobbyScene");
    }
    
}
