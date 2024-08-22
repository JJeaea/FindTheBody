using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FollowOnCollision : MonoBehaviour
{
    public float followDuration = 10f;  // 추적 시간 (10초)
    public float followSpeed;      // 추적 속도
    public Image youDieImage;           // "You Die" 이미지를 참조

    private GameObject target;         // 추적할 캐릭터 B

    void Start()
    {
        if (youDieImage != null)
        {
            youDieImage.enabled = false; // 게임 시작 시 "You Die" 이미지 비활성화
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            target = collision.gameObject;
            StartCoroutine(FollowAndDisplayImage());
        }
    }

    IEnumerator FollowAndDisplayImage()
    {
        float elapsedTime = 0f;

        while (elapsedTime < followDuration && target != null)
        {
            Vector3 direction = (target.transform.position - transform.position).normalized;
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position - target.transform.forward * 2f, followSpeed * Time.deltaTime);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // "You Die" 이미지 활성화
        if (youDieImage != null)
        {
            youDieImage.enabled = true;
        }
    }
}
