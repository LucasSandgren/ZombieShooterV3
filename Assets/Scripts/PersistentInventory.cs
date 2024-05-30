using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentInventory : MonoBehaviour
{
    public static PersistentInventory Instance;
    public Inventory inventory;  // Reference to Inventory component
    public InventoryManager inventoryManager;  // Reference to InventoryManager component

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        // Get references to Inventory and InventoryManager
        inventory = GetComponentInChildren<Inventory>();
        inventoryManager = GetComponentInChildren<InventoryManager>();
    }
}