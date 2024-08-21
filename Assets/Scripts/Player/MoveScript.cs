using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    [SerializeField]
    private float walkSpeed;

    [SerializeField]
    private float RunSpeed;

    [SerializeField]
    private float SitSpeed;

    [SerializeField]
    private float lookSensitivity;

    [SerializeField]
    private float cameraRotationLimit;
    private float currentCameraRotationX;

    [SerializeField]
    private Camera theCamera;
    private Rigidbody myRigid;
    Animator animator;

    bool SitState=false;
    // Start is called before the first frame update
    void Start()
    {
        myRigid = GetComponent<Rigidbody>();  // private
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();                 
        CameraRotation();       
        CharacterRotation();    
    }

    private void Move()
    {
        float _moveDirX = Input.GetAxisRaw("Horizontal");
        float _moveDirZ = Input.GetAxisRaw("Vertical");     
        Vector3 _moveHorizontal = transform.right * _moveDirX;
        Vector3 _moveVertical = transform.forward * _moveDirZ;
        
        

        if(_moveDirX != 0 || _moveDirZ != 0) // 걷는 상태일때
        {
            Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * walkSpeed;
            myRigid.MovePosition(transform.position + _velocity * Time.deltaTime);
        }
        else if(Input.GetButton("Run")) // 뛰는 상태일떄
        {
            Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * RunSpeed;
            myRigid.MovePosition(transform.position + _velocity * Time.deltaTime);
        }
        else if (SitState == false) //앉은 상태일때
        {
            Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * SitSpeed;
            myRigid.MovePosition(transform.position + _velocity * Time.deltaTime);
        }

        animator.SetBool("isRunning", Input.GetButton("Run"));

        if(Input.GetButtonDown("Sit"))
        {
            SitState = !SitState;
            animator.SetBool("isSitting", SitState);

        }
        

        //Debug.Log("Run = " + Input.GetButton("Run"));
        //Debug.Log("Sit = " + Input.GetButtonDown("Sit"));

        if (_moveDirZ < 0)
        {
            animator.SetInteger("isWalking", 2);
        }
        else if (_moveDirX == 0 && _moveDirZ == 0)
        {
            animator.SetInteger("isWalking", 0);
        }
        else if (_moveDirZ >= 0)
        {
            animator.SetInteger("isWalking", 1);
        }
    
    }

    private void CameraRotation()
    {
        float _xRotation = Input.GetAxisRaw("Mouse Y");
        float _cameraRotationX = _xRotation * lookSensitivity;

        currentCameraRotationX -= _cameraRotationX;
        currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);

        theCamera.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f);
    }

    private void CharacterRotation()  // 좌우 캐릭터 회전
    {
        float _yRotation = Input.GetAxisRaw("Mouse X");
        Vector3 _characterRotationY = new Vector3(0f, _yRotation, 0f) * lookSensitivity;
        myRigid.MoveRotation(myRigid.rotation * Quaternion.Euler(_characterRotationY)); // 쿼터니언 * 쿼터니언
        
        // Debug.Log(myRigid.rotation);  // 쿼터니언
        // Debug.Log(myRigid.rotation.eulerAngles); // 벡터
    }
}
