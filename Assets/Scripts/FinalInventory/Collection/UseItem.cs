using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UseItem : MonoBehaviour
{
    private bool isUsing = false;
    private void Start()
    {

        IUsable iUsable = GetComponent<IUsable>(); //Instatiate the interface "IUsable"
    }
    private void InputCheck(IUsable iUsable) //Will check for mouse input when fixed, will activate item.
    {
        if(iUsable != null)
        {
            isUsing = true;
            iUsable.Use();
            isUsing = false;
        }
    }
}
