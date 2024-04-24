using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driving : MonoBehaviour
{
    public float speed = 5.0f;
    public float turnSpeed = 200.0f;
    private Rigidbody2D rb;
    public bool isActive = false;

    public Animator carAnimator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {   
        if (isActive)
        {
            float moveAmount = Input.GetAxis("Vertical") * speed;
            float turnAmount = Input.GetAxis("Horizontal") * turnSpeed;

            rb.MovePosition(rb.position + (Vector2)(transform.up * moveAmount * Time.fixedDeltaTime));
            rb.MoveRotation(rb.rotation - turnAmount * Time.fixedDeltaTime);
            //UpdateModel(moveAmount, turnAmount);
        }
    }
    //private void UpdateModel(float moveAmount, float turnAmount)
    //{
    //    Vector2 moveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;

    //    carAnimator.SetFloat("MoveX", moveDirection.x);
    //    carAnimator.SetFloat("MoveY", moveDirection.y);
    //}
}
