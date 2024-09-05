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
            Debug.Log(hit.collider.gameObject.name);

            // �� ��ȣ�ۿ�
            if (hit.collider.CompareTag("Door_A"))
            {
                Debug.Log("�� �߰�");
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
                    Debug.Log("EŰ ����");
                    hit.collider.GetComponent<DoorScript>().ChangeDoorState();
                    //GameObject.Find(hit.collider.gameObject.name).GetComponent<DoorScript>().ChangeDoorState();
                    //hit.collider.transform.parent.GetComponent<DoorScript>().ChangeDoorState();
                }

            }
            
            // �� ��ȣ�ۿ�
            else if(hit.collider.CompareTag("Coffin"))
            {
                if (isAction == true) //�̹� â�� ����� �ִٸ� ����
                {
                    isAction = false;
                    InteractPanel.SetActive(false);
                }
                isAction = true; // â�� ������ִ� �����ΰ�
                InteractText.text = "[E] �ֱ�";
                InteractPanel.SetActive(true); // â Ȱ��ȭ

                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("EŰ ����");
                    //GameObject.Find(hit.collider.gameObject.name).GetComponent<DoorScript>().ChangeDoorState();
                    //���� �ִ� ��ũ��Ʈ �ֱ�
                }
            }

            else if (hit.collider.CompareTag("Body"))
            {
                if (isAction == true) //�̹� â�� ����� �ִٸ� ����
                {
                    isAction = false;
                    InteractPanel.SetActive(false);
                }
                isAction = true; // â�� ������ִ� �����ΰ�
                InteractText.text = "[E] ȹ��";
                InteractPanel.SetActive(true); // â Ȱ��ȭ

                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("EŰ ����");
                    ItemPickup itemPickup = hit.collider.GetComponent<ItemPickup>();
                    if (itemPickup != null)
                    {
                        Inventory inventory = FindObjectOfType<Inventory>();
                        if (inventory != null)
                        {
                            Item itemToAdd = itemPickup.item; // ������ ������ ���� ����
                            inventory.AddItem(itemToAdd);     // �κ��丮�� ������ �߰�
                            Destroy(itemPickup.gameObject);   // ������Ʈ �ı�
                        }
                    }
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
