using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public bool open = false;
    public string doorAngle;
    public float doorOpenAngle = 90f;
    public float doorCloseAngle = 0f;
    public float smoot = 2f;

    void Start()
    {

    }

    public void ChangeDoorState()
    {
        //Debug.Log("함수호출");
        open = !open;
    }

    void Update()
    {
        if (doorAngle == "Y")
        {
            if (open)
            {
                Quaternion targetRotation = Quaternion.Euler(0, doorOpenAngle, 0);
                transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smoot * Time.deltaTime);
            }
            else
            {
                Quaternion targetRotation2 = Quaternion.Euler(0, doorCloseAngle, 0);
                transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation2, smoot * Time.deltaTime);
            }
        }
        else if (doorAngle == "X")
        {
            if (open)
            {
                Quaternion targetRotation = Quaternion.Euler(doorOpenAngle, 0, 0);
                transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smoot * Time.deltaTime);
            }
            else
            {
                Quaternion targetRotation2 = Quaternion.Euler(doorCloseAngle, 0, 0);
                transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation2, smoot * Time.deltaTime);
            }
        }
        else if (doorAngle == "Z")
        {
            if (open)
            {
                Quaternion targetRotation = Quaternion.Euler(0, 0, doorOpenAngle);
                transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smoot * Time.deltaTime);
            }
            else
            {
                Quaternion targetRotation2 = Quaternion.Euler(0, 0, doorCloseAngle);
                transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation2, smoot * Time.deltaTime);
            }
        }
    }
}
