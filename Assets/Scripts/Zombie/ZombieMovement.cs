using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ZombieMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float detectionRange;

    [SerializeField] private Transform playerTransfrom;

    [SerializeField] private Animator animator;
    private bool isWalking = false;
    private bool isAttacking = false;
    private SpriteRenderer sr;
    private bool up;
    private bool down = true;
    private bool left;
    private bool right;

    private Rigidbody2D rigidBody;

    private Vector2 knockbackDirection;
    private float knockbackTimer;//Controls for how long the zombie will take knockback

    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody2D>(); 
        sr = GetComponent<SpriteRenderer>();
    }

    public void TakeKnockBack(Vector2 direction)
    {
        knockbackDirection = direction;
        knockbackTimer = 0.07f;
    }

    private void FixedUpdate()
    {
        Vector2 vectorToPlayer = playerTransfrom.position - transform.position;

        if (knockbackTimer > 0)
        {
            // Makes the zombie take knockback
            rigidBody.MovePosition(rigidBody.position + knockbackDirection * Time.fixedDeltaTime);
            knockbackTimer -= Time.fixedDeltaTime;

            
        }
        else
        {
            if (vectorToPlayer.magnitude > 0.1f && vectorToPlayer.magnitude <= detectionRange)
            {
                // Makes the zombie walk towards the player
                rigidBody.MovePosition(rigidBody.position + vectorToPlayer.normalized * movementSpeed * Time.fixedDeltaTime);
                isWalking = true;
                animator.SetBool("isWalking", isWalking);
                
            }
            
        }
        //if (isWalking)
        //{
        //    left = rigidBody.position.x < 0;
        //    right = rigidBody.position.x > 0;
        //    up = rigidBody.position.y > 0;
        //    down = rigidBody.position.y < 0;
        //}
        //else
        //{
        //    // NO MOVEMENT, SET ANIMATIONS TO FALSE
        //    left = right = up = down = false;
        //}

        //// SET DIRECTION FOR ANIMATOR
        //animator.SetBool("Left", left);
        //animator.SetBool("Right", right);
        //animator.SetBool("Up", up);
        //animator.SetBool("Down", down);

        //// FLIP LEFT/RIGHT SPRITE
        //if (left)
        //{
        //    sr.flipX = true;
        //}
        //else if (right)
        //{
        //    sr.flipX = false;
        //}
    }
    //private void OnCollisionStay2D(Collision2D collision)
    //{
    //    IsAttacking(collision);
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Optionally handle the collision impact here if needed
    }

    //private void IsAttacking(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        animator.SetBool("isAttacking", true);
    //    }
    //    else
    //    {
    //        animator.SetBool("isAttacking", false);
    //    }
    //}
}
