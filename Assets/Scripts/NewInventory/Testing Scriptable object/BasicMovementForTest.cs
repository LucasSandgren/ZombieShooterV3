using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovementForTest : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of movement
    public Rigidbody2D rb; // Rigidbody component

    Vector2 movement; // Store the movement direction

    // Update is called once per frame
    void Update()
    {
        // Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    // FixedUpdate is called a fixed number of times per second
    void FixedUpdate()
    {
        // Movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
