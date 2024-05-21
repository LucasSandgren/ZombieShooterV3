using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private int cursorVisibilityRequests = 0;
    public void ShowCursor()
    {
        cursorVisibilityRequests++;
        UpdateCursorState();
    }
    public void HideCursor()
    {
        cursorVisibilityRequests = Mathf.Max(0, cursorVisibilityRequests - 1);
        UpdateCursorState();
    }
    public void ResetCursorVisibility()
    {
        cursorVisibilityRequests = 0;
        UpdateCursorState();

    }
    private void UpdateCursorState()
    {
        if (cursorVisibilityRequests > 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = false;
        }
    }
}
