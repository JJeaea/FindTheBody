using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FollowOnCollision : MonoBehaviour
{
    public float followDuration = 10f;  // ���� �ð� (10��)
    public float followSpeed;      // ���� �ӵ�
    public Image youDieImage;           // "You Die" �̹����� ����

    private GameObject target;         // ������ ĳ���� B

    void Start()
    {
        if (youDieImage != null)
        {
            youDieImage.enabled = false; // ���� ���� �� "You Die" �̹��� ��Ȱ��ȭ
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

        // "You Die" �̹��� Ȱ��ȭ
        if (youDieImage != null)
        {
            youDieImage.enabled = true;
        }
    }
}
