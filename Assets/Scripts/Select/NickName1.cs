using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class NickName1 : MonoBehaviourPunCallbacks
{
    public TMP_Text playerNameText; // 닉네임을 표시할 TextMeshPro 텍스트

    // 각각의 버튼을 Unity 에디터에서 할당할 수 있도록 필드 추가
    public Button sulleButton;
    public Button studentButton1;
    public Button studentButton2;
    public Button studentButton3;
    public Button studentButton4;
    public Button studentButton5;
    public Button studentButton6;

    private Button previousClickedButton; // 이전에 클릭된 버튼을 저장
    private string playerName; // 사용자의 닉네임
    private Dictionary<Button, string> roleAssignments = new Dictionary<Button, string>(); // 버튼에 할당된 역할

    private void Start()
    {
        // GameManager에서 플레이어의 닉네임을 가져옵니다.
        playerName = GameManager.instance.OutputPlayerName();

        // 모든 버튼에 클릭 이벤트를 등록합니다.
        sulleButton.onClick.AddListener(() => OnButtonClick(sulleButton));
        studentButton1.onClick.AddListener(() => OnButtonClick(studentButton1));
        studentButton2.onClick.AddListener(() => OnButtonClick(studentButton2));
        studentButton3.onClick.AddListener(() => OnButtonClick(studentButton3));
        studentButton4.onClick.AddListener(() => OnButtonClick(studentButton4));
        studentButton5.onClick.AddListener(() => OnButtonClick(studentButton5));
        studentButton6.onClick.AddListener(() => OnButtonClick(studentButton6));
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
                roleAssignments.Remove(previousClickedButton); // 이전 버튼에서 역할 할당 제거
            }
        }

        // 현재 클릭된 버튼에 사용자의 닉네임을 표시하고 역할 할당
        TMP_Text clickedButtonText = clickedButton.GetComponentInChildren<TMP_Text>();
        if (clickedButtonText != null)
        {
            clickedButtonText.text = playerName;
            roleAssignments[clickedButton] = playerName;
        }

        // 현재 클릭된 버튼을 이전 클릭된 버튼으로 설정합니다.
        previousClickedButton = clickedButton;
    }

    private void Update()
    {
        // 모든 플레이어가 역할을 선택했는지 확인
        if (roleAssignments.Count == PhotonNetwork.PlayerList.Length && PhotonNetwork.PlayerList.Length == 7)
        {
            AssignRolesAndLoadScene();
        }
    }

    private void AssignRolesAndLoadScene()
    {
        // 각 버튼에 할당된 역할을 기반으로 플레이어 역할 설정
        foreach (var kvp in roleAssignments)
        {
            Button button = kvp.Key;
            string assignedPlayerName = kvp.Value;

            // 버튼 이름으로 역할 구분
            if (button == sulleButton)
            {
                GameManager.instance.SetPlayerRole(assignedPlayerName, "Sulle");
            }
            else
            {
                GameManager.instance.SetPlayerRole(assignedPlayerName, "Student");
            }
        }

        // Main Scene으로 이동
        PhotonNetwork.LoadLevel("MainScene");
    }
}
