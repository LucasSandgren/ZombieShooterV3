using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject SlotPrefab;
    public GameObject InventoryMenu;
    public List<InventorySlot> inventorySlots = new List<InventorySlot>(18);
    public bool menuActivated;

    private void OnEnable()
    {
        Inventory.OnInventoryChange += DrawInventory;
    }
    private void OnDisable()
    {
        Inventory.OnInventoryChange -= DrawInventory;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && menuActivated)
        {
            Time.timeScale = 1.0f;
            InventoryMenu.SetActive(false);
            menuActivated = false;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.None;
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && !menuActivated)
        {
            Time.timeScale = 0;
            InventoryMenu.SetActive(true);
            menuActivated = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

    }
    void ResetInventory()
    {
        foreach(Transform childTransform in transform)
        {
            Destroy(childTransform.gameObject);
        }
        inventorySlots = new List<InventorySlot>(18);
    }
    private void DrawInventory(List<InventoryItem> inventory)
    {
        ResetInventory();
        for(int i = 0; i < inventorySlots.Capacity; i++)
        {
            CreateInventorySlot();
        }

        for(int i = 0; i < inventory.Count; i++)
        {
            inventorySlots[i].DrawSlot(inventory[i]);
        }
    }
    void CreateInventorySlot()
    {
        GameObject newSlot = Instantiate(SlotPrefab);
        newSlot.transform.SetParent(transform, false);

        InventorySlot newSlotComponent = newSlot.GetComponent<InventorySlot>();
        newSlotComponent.ClearSlot();

        inventorySlots.Add(newSlotComponent);
    }
}
