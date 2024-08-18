using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CreateRoom : MonoBehaviour
{
    public TMP_InputField roomNameInput;
    private string roomName = null;
    private const string DefaultroomName = "Room 1";

    private void Awake()
    {
        roomNameInput.onEndEdit.AddListener(OnRoomInputEnd);
    }

    private void OnRoomInputEnd(string room)
    {
        if (room.Length > 1 && room.Length < 8)
        {
            GameManager.instance.SettingRoomName(room);
            roomName = room;

            Debug.Log("Room Name: " + roomName);
        }

        if (string.IsNullOrEmpty(room))
        {
            roomName = DefaultroomName;
        }
    }


}
