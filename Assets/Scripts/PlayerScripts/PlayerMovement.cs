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

    private Vector2 faceDirection;
    private Vector2 moveDirection;
    private Vector2 mousePosition;
    [SerializeField] private Health healthScript;

    /* USED FOR PLAYER MODEL ANIMATION */
    public Animator playerAnimator;
    public RectTransform crosshairRectTransform;

    private SpriteRenderer sr;
    private bool slowed;
    private bool up;
    private bool down = true;
    private bool left;
    private bool right;

    [SerializeField]private float  takeDamageCoolDown;
    private float takeDamageTimer;


    void Start()
    {

        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        if (SceneValues.earlierScene == "BuyShopScene")
        {
            oldPos = SceneValues.positionBeforeBuyShop;
            //problemet handlar kanske om att det är olika data? Detta är iallafall problemet. 

            transform.position = new Vector3(oldPos.x, oldPos.y, oldPos.z);


            //rigidBody.position = SceneValues.positionBeforeBuyShop.position;

        }

        //currentSpeed = 3.0f;

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

        takeDamageTimer -= Time.deltaTime;
        
    }

    private void FixedUpdate()
    {
        rigidBody.MovePosition(rigidBody.position + moveDirection * currentSpeed * Time.fixedDeltaTime);

        /* SETS CROSSHAIR AT MOUSE POS */
        crosshairRectTransform.position = Input.mousePosition;
        
        /* SET OPENING OF FOG AT PLAYER */
        vfxRenderer.SetVector3("ColliderPos", rigidBody.position);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        GameObject collisionObject = collision.gameObject;

        if (takeDamageTimer <= 0)
        {
            if (collisionObject.CompareTag("Zombie"))
            {
                healthScript.TakeDamage(collisionObject.GetComponent<ZombieAttack>().attackDamage);
                takeDamageTimer = takeDamageCoolDown;
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        GameObject collisionObject = collision.gameObject;

        if (takeDamageTimer <= 0)
        {
            if (collisionObject.CompareTag("Enviromental Hazard"))
            {
                healthScript.TakeDamage(collisionObject.GetComponent<DamagingSpikes>().damage);
                takeDamageTimer = takeDamageCoolDown;
            }
        }
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
