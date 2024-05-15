using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PayToOpen : MonoBehaviour
{
    private bool inRange = false;

    [SerializeField] private int cost = 0;

    void Update()
    {
        if (inRange && Input.GetKeyDown(KeyCode.E))
        {
            if (OnStart.coins >= cost)
            {
                OnStart.coins -= cost;
                Destroy(gameObject);
            }
        }
    }

    //Ensure player is in range
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inRange = false;
        }
    }
}
