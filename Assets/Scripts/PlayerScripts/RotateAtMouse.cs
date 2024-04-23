using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAtMouse : MonoBehaviour
{
    private Vector2 faceDirection;
    private Vector2 mousePosition;

    void Update()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        //Gets the vector from the object to the mouse
        faceDirection = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);

        //Rotates the object
        transform.right = faceDirection;
    }
}
