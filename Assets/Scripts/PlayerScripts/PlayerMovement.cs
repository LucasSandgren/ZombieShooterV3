using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Jobs;
using UnityEngine.VFX;

public class CollisionMovement : MonoBehaviour
{
    public VisualEffect vfxRenderer;

    public Camera camera;

    private (float x, float y, float z) oldPos;

    private Rigidbody2D rigidBody;

    private float currentSpeed = 0.0f;

    private Vector2 moveDirection;
    private Vector2 mousePosition;

    /* USED FOR PLAYER MODEL ANIMATION */
    public Animator playerAnimator;
    public RectTransform crosshairRectTransform;

    private SpriteRenderer sr;
    private bool slowed;
    private bool up;
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
        Vector3 currentRigidBodyPosition = new Vector3(rigidBody.position.x, rigidBody.position.y, transform.position.z);

        // Rotating rectangle to mouse position
        // setting a direction for the rotation based on
        // transform and mouse position and then sets a crosshair to the positon of the mouse
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 playerPosition = new Vector2(transform.position.x, transform.position.y);
        Vector2 directionToMouse = (mousePosition - playerPosition).normalized;
        float distanceToMouse = Vector2.Distance(playerPosition,mousePosition);

        float maxDistance = 3.5f;
        if (distanceToMouse > maxDistance)
        {
            mousePosition = playerPosition + directionToMouse * maxDistance;
        }
        crosshairRectTransform.position = Camera.main.WorldToScreenPoint(mousePosition);

        if (Input.GetKeyDown(KeyCode.H))
        {
            OnStart.coins += 1;
        }

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
        
        /* SET OPENING OF FOG AT PLAYER */
        vfxRenderer.SetVector3("ColliderPos", rigidBody.position);
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
}
