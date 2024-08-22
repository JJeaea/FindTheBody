using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public Camera playerCamera;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
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
    }
}
