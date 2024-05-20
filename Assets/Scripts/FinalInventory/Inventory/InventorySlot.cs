using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;
using UnityEditor.ShaderGraph.Drawing;

public class InventorySlot : MonoBehaviour, IPointerClickHandler
{
    public Image icon;
    public TextMeshProUGUI stackSizeText;
    public TextMeshProUGUI labelText;
    private InventoryItem currentItem;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Slot clicked");
        if(currentItem != null)
        {
            Debug.Log("Using item " + currentItem.itemData.displayName);
        }
    }
    public void ClearSlot() //If there is no itemData in the slot, clear it
    {
        currentItem = null;
        icon.enabled = false;
        stackSizeText.enabled = false;
        labelText.enabled = false;
    }
    public void DrawSlot(InventoryItem item) //Redraws the slots every time an item gets added, not the best but is a good solution for smaller inventories
    {
        currentItem = item;
        if(item == null) //If the item is nul
        {
            ClearSlot(); //Clear the slot
            return;
        }
        //Else if the item != null
        icon.enabled = true;
        stackSizeText.enabled = true;
        labelText.enabled = true;
        //Setting the variables
        icon.sprite = item.itemData.icon;
        stackSizeText.text = item.stackSize.ToString();
        labelText.text = item.itemData.displayName;
    }
}
