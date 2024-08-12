using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NickName1 : MonoBehaviour
{
    public TMP_Text playerNameText; // 닉네임을 표시할 TextMeshPro 텍스트
    private Button previousClickedButton; // 이전에 클릭된 버튼을 저장
    private string playerName; // 사용자의 닉네임

    private void Start()
    {
        // GameManager에서 플레이어의 닉네임을 가져옵니다.
        playerName = GameManager.instance.OutputPlayerName();

        // 모든 자식 버튼에 클릭 이벤트를 등록합니다.
        Button[] buttons = GetComponentsInChildren<Button>();
        foreach (Button button in buttons)
        {
            Button currentButton = button;  // 로컬 변수를 생성하여 캡처
            button.onClick.AddListener(() => OnButtonClick(currentButton));
        }
    }

    private void OnButtonClick(Button clickedButton)
    {
        // 이전에 클릭된 버튼의 텍스트를 초기화합니다.
        if (previousClickedButton != null && previousClickedButton != clickedButton)
        {
            TMP_Text previousButtonText = previousClickedButton.GetComponentInChildren<TMP_Text>();
            if (previousButtonText != null)
            {
                previousButtonText.text = "참가"; // 초기 텍스트로 설정
            }
        }

        // 현재 클릭된 버튼에 사용자의 닉네임을 표시합니다.
        TMP_Text clickedButtonText = clickedButton.GetComponentInChildren<TMP_Text>();
        if (clickedButtonText != null)
        {
            clickedButtonText.text = playerName;
        }

        // 현재 클릭된 버튼을 이전 클릭된 버튼으로 설정합니다.
        previousClickedButton = clickedButton;
    }
}
