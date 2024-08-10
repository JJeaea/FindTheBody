using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ChangeImage : MonoBehaviour
{
    // 버튼과 스프라이트를 두 개씩 관리
    public Button createRoomButton;  // 방 만들기 버튼
    public Button joinRoomButton;    // 방 참가하기 버튼

    public Sprite createRoomImageDefault;  // 방 만들기 기본 이미지
    public Sprite createRoomImageChanged;  // 방 만들기 변경된 이미지

    public Sprite joinRoomImageDefault;    // 방 참가하기 기본 이미지
    public Sprite joinRoomImageChanged;    // 방 참가하기 변경된 이미지

    public GameObject creatRoomPopup;
    public GameObject joinRoomPopup;

    private bool isDefaultState = true;  // 현재 상태를 트래킹

    // 방 참가하기 버튼을 눌렀을 때 실행될 함수
    public void OnJoinRoomButtonClicked()
    {
        if (isDefaultState)
        {
            // 방 만들기 버튼 : 흰 -> 회
            createRoomButton.image.sprite = createRoomImageChanged; //회
            // 방 참가하기 버튼 : 회 -> 흰
            joinRoomButton.image.sprite = joinRoomImageChanged; // 흰

            creatRoomPopup.SetActive(false);
            joinRoomPopup.SetActive(true);
            
        }
    }

    // 방 만들기 버튼을 눌렀을 때 실행될 함수
    public void OnCreateRoomButtonClicked()
    {
        if (isDefaultState)
        {
            // 방 만들기 버튼 : 회 -> 흰
            createRoomButton.image.sprite = createRoomImageDefault; // 흰
            // 방 참가하기 버튼 : 흰 -> 회
            joinRoomButton.image.sprite = joinRoomImageDefault; // 회

            joinRoomPopup.SetActive(false);
            creatRoomPopup.SetActive(true);
            
        }
    }
}
