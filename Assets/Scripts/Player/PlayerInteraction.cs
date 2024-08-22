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
                        Item itemToAdd = itemPickup.item; // 아이템 정보를 먼저 저장
                        inventory.AddItem(itemToAdd);     // 인벤토리에 아이템 추가
                        Destroy(itemPickup.gameObject);   // 오브젝트 파괴
                    }
                }
            }
        }
    }
}
