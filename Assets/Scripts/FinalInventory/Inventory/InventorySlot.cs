using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;
using UnityEditor.ShaderGraph.Drawing;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI stackSizeText;
    public TextMeshProUGUI labelText;
    private InventoryItem currentItem;
    private Inventory inventory;
    private Button button;
    private void Start()
    {
        inventory = GetComponent<Inventory>();
        button = GetComponent<Button>();
    }
    public void ClearSlot() //If there is no itemData in the slot, clear it
    {
        icon.enabled = false;
        stackSizeText.enabled = false;
        labelText.enabled = false;
    }
    public void DrawSlot(InventoryItem item) //Redraws the slots every time an item gets added, not the best but is a good solution for smaller inventories
    {
        if(item == null) //If the item is nul
        {
            ClearSlot(); //Clear the slot
            return;
        }
        //Else if the item != null
        currentItem = item;
        icon.enabled = true;
        stackSizeText.enabled = true;
        labelText.enabled = true;
        //Setting the variables
        icon.sprite = item.itemData.icon;
        stackSizeText.text = item.stackSize.ToString();
        labelText.text = item.itemData.displayName;
    }
    public void OnMouseDown()
    {
            Debug.Log("Click");

    }
}
