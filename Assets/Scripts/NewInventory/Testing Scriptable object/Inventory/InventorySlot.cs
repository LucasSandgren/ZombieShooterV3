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

    public void ClearSlot()
    {
        icon.enabled = false;
        stackSizeText.enabled = false;
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

        icon.sprite = item.ItemData.icon;
        //stackSizeText = item.stackSize.ToString();
    }
}
