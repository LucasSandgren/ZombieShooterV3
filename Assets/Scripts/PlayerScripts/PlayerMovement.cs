using System;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.Jobs;
using System.Collections;
using Unity.VisualScripting;
using System.Collections.Generic;

public class CollisionMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private VisualEffect vfxRenderer;
    [SerializeField] private Camera camera;
    [Header("Animation")]
    /* USED FOR PLAYER MODEL ANIMATION */
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private RectTransform crosshairRectTransform;
    [Header("Audio Source")]
    [SerializeField] private AudioSource audio;
    [SerializeField] private AudioClip[] footsteps;
    private int stepIndex = 0;
    private float stepTimer = 0;
    private float stepInterval = 0.5f;

    private (float x, float y, float z) oldPos;
    private float currentSpeed = 0.0f;
    private Rigidbody2D rigidBody;
    private Vector2 moveDirection;
    private Vector2 mousePosition;
    private SpriteRenderer sr;
    private bool slowed; 
    private bool up; // FOR MOVEMENT ANIMATION
    private bool down = true;
    private bool left;
    private bool right;

    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        // Confine and hide cursor
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    void Update()
    {
        playerAnimator.SetFloat("Speed", currentSpeed);
        crosshairRectTransform.position = Input.mousePosition;

        // GetAxis() returns a value of -1, 0 or 1 depending on button clicked, Which button does what can be seen under "input manager" in project settings
        // Its normalized so that the speed will be consistent even if you are walking diagonaly
        moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0).normalized;
        currentSpeed = moveDirection == Vector2.zero ? 0.0f : (slowed ? 1.0f : 3.0f);

        /* USED FOR SWITCHING ANIMATION STATES */
        if (currentSpeed > 0)
        {
            left = moveDirection.x < 0;
            right = moveDirection.x > 0;
            up = moveDirection.y > 0;
            down = moveDirection.y < 0;

            /* STEPS SFX */
            stepTimer -= Time.deltaTime;
            if (stepTimer <= 0f)
            {
                PlayStep();
                stepTimer = stepInterval;
            }
        }
        else
        {
            // NO MOVEMENT, SET ANIMATIONS TO FALSE
            left = right = up = down = false;
        }

        // SET DIRECTION FOR ANIMATOR
        playerAnimator.SetBool("left", left);
        playerAnimator.SetBool("right", right);
        playerAnimator.SetBool("up", up);
        playerAnimator.SetBool("down", down);

        // FLIP LEFT/RIGHT SPRITE
        if (left)
        {
            sr.flipX = true;
        }
        else if (right)
        {
            sr.flipX = false;
        }
    }
    private void FixedUpdate()
    {
        rigidBody.MovePosition(rigidBody.position + moveDirection * currentSpeed * Time.fixedDeltaTime);

        /* SETS CROSSHAIR AT MOUSE POS */
        crosshairRectTransform.position = Input.mousePosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Slowing Area")
        {
            slowed = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Slowing Area")
        {
            slowed = false;
        }
    }
    private void PlayStep()
    {
        if (footsteps.Length == 0) return;
        
        audio.clip = footsteps[stepIndex];
        audio.Play();
        stepIndex = (stepIndex + 1) % footsteps.Length;
    }
}
