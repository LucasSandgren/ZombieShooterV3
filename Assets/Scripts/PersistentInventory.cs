using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistentInventory : MonoBehaviour
{
    public static PersistentInventory Instance;
    public Inventory inventory;  // Reference to Inventory component
    public InventoryManager inventoryManager;  // Reference to InventoryManager component

    public List<string> scenesWithoutInventory;

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
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scenesWithoutInventory.Contains(scene.name))
        {
            inventoryManager.gameObject.SetActive(false);
        }
        else
        {
            inventoryManager.gameObject.SetActive(true);
            inventoryManager.DrawInventory(inventory.inventory);
        }
    }
}