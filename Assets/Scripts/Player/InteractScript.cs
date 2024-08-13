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
                    hit.collider.transform.parent.GetComponent<DoorScript>().ChangeDoorState();
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
