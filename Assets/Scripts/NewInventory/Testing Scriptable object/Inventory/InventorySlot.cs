using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using TMPro;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI stackSizeText;
    public TextMeshProUGUI labelText;
    public void ClearSlot()
    {
        icon.enabled = false;
        stackSizeText.enabled = false;
        labelText.enabled = false;
    }
    public void DrawSlot(InventoryItem item)
    {
        if(item == null)
        {
            ClearSlot();
            return;
        }
        icon.enabled = true;
        stackSizeText.enabled = true;
        labelText.enabled = true;

        icon.sprite = item.itemData.icon;
        stackSizeText.text = item.stackSize.ToString();
        labelText.text = item.itemData.displayName;
    }
}
