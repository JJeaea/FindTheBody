using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class InteractScript : MonoBehaviour
{
    public float interactDiastance = 5f;

    public TextMeshProUGUI InteractText;
    public GameObject InteractPanel;
    public bool isAction;

    void Start()
    {
        
    }

    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward*10, Color.yellow);
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, interactDiastance))
        {

            if (hit.collider.CompareTag("Door_A"))
            {
                if (isAction == true) //�̹� â�� ����� �ִٸ� ����
                {
                    isAction = false;
                    InteractPanel.SetActive(false);
                }
                isAction = true; // â�� ������ִ� �����ΰ�
                InteractText.text = "[E] ����, �ݱ�";
                InteractPanel.SetActive(true); // â Ȱ��ȭ

                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.transform.parent.GetComponent<DoorScript>().ChangeDoorState();
                }

            }
            /* //������ �߰��� ���ο� �±� �߰� �� ���⿡ �߰�
            else if(hit.collider.CompareTag("Item"))
            {
            }
            */
        }
        else
        {
            isAction = false;
            InteractText.text = "";
            InteractPanel.SetActive(false);
        }

    }
}
