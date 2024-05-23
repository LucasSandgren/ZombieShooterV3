using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryPanel : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Pointer entered inventory panel");
        UIManager.Instance?.ShowCursor();

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Pointer exited inventory panel");
        UIManager.Instance?.HideCursor();

    }
}