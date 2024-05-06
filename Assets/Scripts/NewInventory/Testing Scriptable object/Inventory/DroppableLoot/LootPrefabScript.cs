using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class LootPrefabScript : MonoBehaviour, ICollectible
{
    private ItemData itemData;
    private InventoryManager inventory;
    void Start()
    {
        inventory = FindObjectOfType<InventoryManager>();
        if( inventory == null)
        {
            Debug.Log("Inventory not found in the scene");
        }
    }
    public void SetItemData(ItemData itemData)
    {
        this.itemData = itemData;
    }
    public void Collect()
    {
        //if(itemData == null)
        //{
        //    Debug.Log("Warning item not found)");
        //    return;
        //}
        //if(itemData == )
        //{
        //    inventory.
        //}
        //else if(itemData is CoinData)
        //{
        //    inventory.Add(itemData);
        //}
        Destroy(gameObject);
    }
}
