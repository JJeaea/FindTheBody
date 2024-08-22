using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>(); // �κ��丮�� �� ������ ���
    public GameObject inventoryPanel; // �κ��丮�� ǥ���� �г�
    public GameObject inventorySlotPrefab; // ������ ���� ������
    private bool isInventoryOpen = false; // �κ��丮 �г��� ���� �ִ��� ����

    void Start()
    {
        inventoryPanel.SetActive(isInventoryOpen); // �κ��丮 �г� �ʱ� ����
        // UpdateInventoryUI()�� ���⼭ ȣ������ ����
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) // 1�� Ű�� ������
        {
            ToggleInventory();
        }
    }

    public void ToggleInventory()
    {
        isInventoryOpen = !isInventoryOpen; // ���¸� ����
        inventoryPanel.SetActive(isInventoryOpen); // �г��� Ȱ��ȭ/��Ȱ��ȭ
    }

    public void AddItem(Item newItem)
    {
        if (newItem != null)
        {
            items.Add(newItem);
            UpdateInventoryUI();
        }
    }

    void UpdateInventoryUI()
    {
        // ���� ������ ���� ����
        foreach (Transform child in inventoryPanel.transform)
        {
            Destroy(child.gameObject);
        }

        // ���ο� ������ ���� �߰�
        foreach (Item item in items)
        {
            if (item != null) // �������� �ִ� ��쿡�� ���� ����
            {
                GameObject slot = Instantiate(inventorySlotPrefab, inventoryPanel.transform);
                Image icon = slot.transform.GetChild(0).GetComponent<Image>(); // ������ ù��° �ڽ��� ������ �̹���
                icon.sprite = item.itemIcon; // �������� �������� ���Կ� ����
            }
        }
    }
}
