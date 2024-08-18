using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoomDisplay : MonoBehaviour
{
    public TMP_Text roomNameText;
    void Start()
    {
        roomNameText.text = GameManager.instance.OutputRoomName();
        Debug.Log(GameManager.instance.OutputRoomName());
    }
}