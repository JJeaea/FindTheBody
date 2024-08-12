using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NickName1 : MonoBehaviour
{
    public TMP_Text playerNameText; // �г����� ǥ���� TextMeshPro �ؽ�Ʈ
    private Button previousClickedButton; // ������ Ŭ���� ��ư�� ����
    private string playerName; // ������� �г���

    private void Start()
    {
        // GameManager���� �÷��̾��� �г����� �����ɴϴ�.
        playerName = GameManager.instance.OutputPlayerName();

        // ��� �ڽ� ��ư�� Ŭ�� �̺�Ʈ�� ����մϴ�.
        Button[] buttons = GetComponentsInChildren<Button>();
        foreach (Button button in buttons)
        {
            Button currentButton = button;  // ���� ������ �����Ͽ� ĸó
            button.onClick.AddListener(() => OnButtonClick(currentButton));
        }
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
            }
        }

        // ���� Ŭ���� ��ư�� ������� �г����� ǥ���մϴ�.
        TMP_Text clickedButtonText = clickedButton.GetComponentInChildren<TMP_Text>();
        if (clickedButtonText != null)
        {
            clickedButtonText.text = playerName;
        }

        // ���� Ŭ���� ��ư�� ���� Ŭ���� ��ư���� �����մϴ�.
        previousClickedButton = clickedButton;
    }
}
