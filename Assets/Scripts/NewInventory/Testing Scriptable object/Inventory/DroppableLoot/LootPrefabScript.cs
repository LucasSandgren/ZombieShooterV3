using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class LootPrefabScript : MonoBehaviour, ICollectible
{
    private ItemData itemData;
    private Inventory inventory;
    void Start()
    {
        inventory = FindObjectOfType<Inventory>();
    }
    public void SetItemData(ItemData itemData)
    {
        this.itemData = itemData;
    }
    public void Collect()
    {
        inventory.Add(itemData);
        Destroy(gameObject);
    }
}
