using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ChangeImage : MonoBehaviour
{
    // ��ư�� ��������Ʈ�� �� ���� ����
    public Button createRoomButton;  // �� ����� ��ư
    public Button joinRoomButton;    // �� �����ϱ� ��ư

    public Sprite createRoomImageDefault;  // �� ����� �⺻ �̹���
    public Sprite createRoomImageChanged;  // �� ����� ����� �̹���

    public Sprite joinRoomImageDefault;    // �� �����ϱ� �⺻ �̹���
    public Sprite joinRoomImageChanged;    // �� �����ϱ� ����� �̹���

    public GameObject creatRoomPopup;
    public GameObject joinRoomPopup;

    private bool isDefaultState = true;  // ���� ���¸� Ʈ��ŷ

    // �� �����ϱ� ��ư�� ������ �� ����� �Լ�
    public void OnJoinRoomButtonClicked()
    {
        if (isDefaultState)
        {
            // �� ����� ��ư : �� -> ȸ
            createRoomButton.image.sprite = createRoomImageChanged; //ȸ
            // �� �����ϱ� ��ư : ȸ -> ��
            joinRoomButton.image.sprite = joinRoomImageChanged; // ��

            creatRoomPopup.SetActive(false);
            joinRoomPopup.SetActive(true);
            
        }
    }

    // �� ����� ��ư�� ������ �� ����� �Լ�
    public void OnCreateRoomButtonClicked()
    {
        if (isDefaultState)
        {
            // �� ����� ��ư : ȸ -> ��
            createRoomButton.image.sprite = createRoomImageDefault; // ��
            // �� �����ϱ� ��ư : �� -> ȸ
            joinRoomButton.image.sprite = joinRoomImageDefault; // ȸ

            joinRoomPopup.SetActive(false);
            creatRoomPopup.SetActive(true);
            
        }
    }
}
