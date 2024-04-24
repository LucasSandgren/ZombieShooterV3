using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAtMouse : MonoBehaviour
{
    private Vector2 faceDirection;
    private Vector2 mousePosition;
    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        //Gets the vector from the object to the mouse
        faceDirection = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);

        /* FLIPS THE WEAPON DEPENDING IF RIGHT/LEFT SIDE 
        THIS FUNCTION CALCULATES ANGLE IN RADIANS BETWEEN X AND MOUSE
        RETURNS VALUE IN RADIANS
        RAD2DEG 180/PI CONVERTS RADIANS TO DEGREES
         */
        
        float angle = Mathf.Atan2(faceDirection.y, faceDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        
        if (faceDirection.x < 0)
        {
            sr.flipY = true;
        }
        else
        {
            sr.flipY = false;
        }
        //Rotates the object
        //transform.right = faceDirection;
    }
}
