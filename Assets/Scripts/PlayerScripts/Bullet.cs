using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bullet : MonoBehaviour
{
    private new Rigidbody2D rigidbody;
    private Vector2 direction;
    
    [System.NonSerialized] public float timerUntilDestoyed;
    [System.NonSerialized] public int damage;
    [System.NonSerialized] public float speed;

    public GameObject bloodSplatter;



    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        //Gets the mouse position
        Vector2 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        //Normalizes the vector from the bullets position to the mouse position, to create a vector representing the direction the bullet should move
        direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y).normalized;
    }

    void Update()
    {
        timerUntilDestoyed -= Time.deltaTime;
        if (timerUntilDestoyed <= 0)
        {
            Destroy(gameObject);
        }
    }
    void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + direction * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Zombie")
        {
            if (bloodSplatter)
            {
                Vector2 hitDirection = -direction; // OPPOSITE OF BULLET DIRECTION
                float angle = Mathf.Atan2(hitDirection.y, hitDirection.x) * Mathf.Rad2Deg;  // Convert direction to angle
                Quaternion rotation = Quaternion.Euler(0f, 0f, angle + 100 );  // Adjust for sprite orientation if necessary

                Instantiate(bloodSplatter, other.transform.position, rotation);
            }
        }

        if (other.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
