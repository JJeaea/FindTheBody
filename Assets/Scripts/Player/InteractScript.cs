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

            // 문 상호작용
            if (hit.collider.CompareTag("Door_A"))
            {
                Debug.Log("문 발견");
                if (isAction == true) //이미 창이 띄워져 있다면 끄기
                {
                    isAction = false;
                    InteractPanel.SetActive(false);
                }
                isAction = true; // 창이 띄워져있는 상태인가
                InteractText.text = "[E] 열기, 닫기";
                InteractPanel.SetActive(true); // 창 활성화

                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("E키 누름");
                    hit.collider.GetComponent<DoorScript>().ChangeDoorState();
                    //GameObject.Find(hit.collider.gameObject.name).GetComponent<DoorScript>().ChangeDoorState();
                    //hit.collider.transform.parent.GetComponent<DoorScript>().ChangeDoorState();
                }

            }
            
            // 관 상호작용
            else if(hit.collider.CompareTag("Coffin"))
            {
                if (isAction == true) //이미 창이 띄워져 있다면 끄기
                {
                    isAction = false;
                    InteractPanel.SetActive(false);
                }
                isAction = true; // 창이 띄워져있는 상태인가
                InteractText.text = "[E] 넣기";
                InteractPanel.SetActive(true); // 창 활성화

                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("E키 누름");
                    //GameObject.Find(hit.collider.gameObject.name).GetComponent<DoorScript>().ChangeDoorState();
                    //관에 넣는 스크립트 넣기
                }
            }

            else if (hit.collider.CompareTag("Body"))
            {
                if (isAction == true) //이미 창이 띄워져 있다면 끄기
                {
                    isAction = false;
                    InteractPanel.SetActive(false);
                }
                isAction = true; // 창이 띄워져있는 상태인가
                InteractText.text = "[E] 획득";
                InteractPanel.SetActive(true); // 창 활성화

                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("E키 누름");
                    ItemPickup itemPickup = hit.collider.GetComponent<ItemPickup>();
                    if (itemPickup != null)
                    {
                        Inventory inventory = FindObjectOfType<Inventory>();
                        if (inventory != null)
                        {
                            Item itemToAdd = itemPickup.item; // 아이템 정보를 먼저 저장
                            inventory.AddItem(itemToAdd);     // 인벤토리에 아이템 추가
                            Destroy(itemPickup.gameObject);   // 오브젝트 파괴
                        }
                    }
                }
            }

            /* //아이템 추가나 새로운 태그 추가 시 여기에 추가
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
