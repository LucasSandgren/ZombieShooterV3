using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Action<List<InventoryItem>> OnInventoryChange;
    public List<InventoryItem> inventory = new();
    private Dictionary<ItemData, InventoryItem> itemDictionary = new();

    private void OnEnable()
    {
        Coin.OnCoinCollected += Add;
        MedKit.OnMedKitCollected += Add;
        Syringe.OnSyringeCollected += Add;
        Bandage.OnBandageCollect += Add;
    }
    private void OnDisable()
    {

    }
    public void Add(ItemData itemData) //Takes itemdata from the itemdata script and adds it into the list of inventory items
    {
        if(itemDictionary.TryGetValue(itemData, out InventoryItem item))
        {
            item.AddToStack();
            OnInventoryChange?.Invoke(inventory);
        }
        else
        {
            InventoryItem newItem = new InventoryItem(itemData);
            inventory.Add(newItem);
            itemDictionary.Add(itemData, newItem);
            OnInventoryChange?.Invoke(inventory);
        }
    }
    public void Remove(ItemData itemData) //Same as add but removes it
    {
        if(itemDictionary.TryGetValue(itemData, out InventoryItem item))
        {
            item.RemoveFromStack();
            if(item.stackSize == 0)
            {
                inventory.Remove(item);
                itemDictionary.Remove(itemData);
            }
            OnInventoryChange?.Invoke(inventory);
        }
    }
}