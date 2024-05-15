using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Action<List<InventoryItem>> OnInventoryChange;
    public List<InventoryItem> inventory = new();
    private Dictionary<ItemData, InventoryItem> itemDictionary = new();

    private void OnEnable() //Adds the different items to the inventory
    {
        Coin.OnCoinCollected += Add;
        MedKit.OnMedKitCollected += Add;
        Syringe.OnSyringeCollected += Add;
        Bandage.OnBandageCollect += Add;
        FuelTank.OnFuelTankCollected += Add;
    }
    private void OnDisable()
    {

    }
    public void Add(ItemData itemData) //Takes itemdata from the itemdata script and adds it into the list of inventory items
    {
        if (itemDictionary.TryGetValue(itemData, out InventoryItem item)) //If an item already exists
        {
            item.AddToStack();
            OnInventoryChange?.Invoke(inventory);
        }
        else //Add the itemdata and invoke the inventory change (Redraw)
        {
            InventoryItem newItem = new InventoryItem(itemData);
            inventory.Add(newItem);
            itemDictionary.Add(itemData, newItem);
            OnInventoryChange?.Invoke(inventory);
        }
    }
    public void Remove(ItemData itemData) //Same as add but removes it
    {
        if (itemDictionary.TryGetValue(itemData, out InventoryItem item))
        {
            item.RemoveFromStack(); //Remove one instance of the item
            if (item.stackSize == 0) //If the item stack reaches 0
            {
                inventory.Remove(item); //Delete the item from the inventory visually
                itemDictionary.Remove(itemData); //Delete the itemData
            }
            OnInventoryChange?.Invoke(inventory); //Redraw inventory
        }
    }

    public bool IsItemInInventory(string itemName, int quantity)
    {
        //Loops trought the inventory
        for (int i = 0; i < inventory.Count - 1; i++)
        {
            Debug.Log(inventory[i].itemData.displayName + "     " +  inventory[i].stackSize);
            //Checks if the current item in the inventory is the correct and that there is enough of it
            if (inventory[i].itemData.displayName == itemName && inventory[i].stackSize >= quantity)
            {
                return true;
            }
        }

        return false;
    }
}
