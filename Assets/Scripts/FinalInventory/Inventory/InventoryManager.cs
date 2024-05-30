using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject slotPrefab;
    public List<InventorySlot> inventorySlots = new List<InventorySlot>(13);
    //public InventorySlot inventorySlot;

    private void Awake()
    {
        if (PersistentInventory.Instance != null)
        {
            PersistentInventory.Instance.inventoryManager = this;
        }
    }
    private void OnEnable()
    {
        Inventory.OnInventoryChange += DrawInventory;
        if (PersistentInventory.Instance != null && PersistentInventory.Instance.inventory != null)
        {
            DrawInventory(PersistentInventory.Instance.inventory.inventory);  // Redraw inventory on enable
        }
    }
    private void OnDisable()
    {
        Inventory.OnInventoryChange -= DrawInventory;
    }

    void ResetInventory()
    {
        foreach(Transform childTransform in transform)
        {
            Destroy(childTransform.gameObject);
        }
        inventorySlots.Clear();
        inventorySlots = new List<InventorySlot>(13);
    }
    private void DrawInventory(List<InventoryItem> inventory)
    {
        ResetInventory();
        for (int i = 0; i < inventorySlots.Capacity; i++)
        {
            CreateInventorySlot();
        }

        for (int i = 0; i < inventory.Count; i++)
        {
            inventorySlots[i].DrawSlot(inventory[i]);

        }
    }
    void CreateInventorySlot()
    {
        GameObject newSlot = Instantiate(slotPrefab);
        newSlot.transform.SetParent(transform, false);

        InventorySlot newSlotComponent = newSlot.GetComponent<InventorySlot>();
        newSlotComponent.ClearSlot();

        inventorySlots.Add(newSlotComponent);

    }
}
