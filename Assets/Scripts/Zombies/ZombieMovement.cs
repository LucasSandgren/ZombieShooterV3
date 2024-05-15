using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ZombieMovement : MonoBehaviour
{
    [Header("Variables: ")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private float detectionRange;

    [Header("References: ")]
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
            //Knocks back the zombie
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
    }
}
