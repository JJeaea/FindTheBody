using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class NickName1 : MonoBehaviourPunCallbacks
{
    public TMP_Text playerNameText; // �г����� ǥ���� TextMeshPro �ؽ�Ʈ

    // ������ ��ư�� Unity �����Ϳ��� �Ҵ��� �� �ֵ��� �ʵ� �߰�
    public Button sulleButton;
    public Button studentButton1;
    public Button studentButton2;
    public Button studentButton3;
    public Button studentButton4;
    public Button studentButton5;
    public Button studentButton6;

    private Button previousClickedButton; // ������ Ŭ���� ��ư�� ����
    private string playerName; // ������� �г���
    private Dictionary<Button, string> roleAssignments = new Dictionary<Button, string>(); // ��ư�� �Ҵ�� ����

    private void Start()
    {
        // GameManager���� �÷��̾��� �г����� �����ɴϴ�.
        playerName = GameManager.instance.OutputPlayerName();

        // ��� ��ư�� Ŭ�� �̺�Ʈ�� ����մϴ�.
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
        // ������ Ŭ���� ��ư�� �ؽ�Ʈ�� �ʱ�ȭ�մϴ�.
        if (previousClickedButton != null && previousClickedButton != clickedButton)
        {
            TMP_Text previousButtonText = previousClickedButton.GetComponentInChildren<TMP_Text>();
            if (previousButtonText != null)
            {
                previousButtonText.text = "����"; // �ʱ� �ؽ�Ʈ�� ����
                roleAssignments.Remove(previousClickedButton); // ���� ��ư���� ���� �Ҵ� ����
            }
        }

        // ���� Ŭ���� ��ư�� ������� �г����� ǥ���ϰ� ���� �Ҵ�
        TMP_Text clickedButtonText = clickedButton.GetComponentInChildren<TMP_Text>();
        if (clickedButtonText != null)
        {
            clickedButtonText.text = playerName;
            roleAssignments[clickedButton] = playerName;
        }

        // ���� Ŭ���� ��ư�� ���� Ŭ���� ��ư���� �����մϴ�.
        previousClickedButton = clickedButton;
    }

    private void Update()
    {
        // ��� �÷��̾ ������ �����ߴ��� Ȯ��
        if (roleAssignments.Count == PhotonNetwork.PlayerList.Length && PhotonNetwork.PlayerList.Length == 7)
        {
            AssignRolesAndLoadScene();
        }
    }

    private void AssignRolesAndLoadScene()
    {
        // �� ��ư�� �Ҵ�� ������ ������� �÷��̾� ���� ����
        foreach (var kvp in roleAssignments)
        {
            Button button = kvp.Key;
            string assignedPlayerName = kvp.Value;

            // ��ư �̸����� ���� ����
            if (button == sulleButton)
            {
                GameManager.instance.SetPlayerRole(assignedPlayerName, "Sulle");
            }
            else
            {
                GameManager.instance.SetPlayerRole(assignedPlayerName, "Student");
            }
        }

        // Main Scene���� �̵�
        PhotonNetwork.LoadLevel("MainScene");
    }
}
