using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PayToOpen : MonoBehaviour
{
    private bool inRange = false;

    [SerializeField] private int cost = 0;
    [SerializeField] private TextMeshProUGUI popupText;

    private void Start()
    {
        popupText.enabled = false;
    }

    void Update()
    {
        if (inRange && Input.GetKeyDown(KeyCode.E))
        {
            if (PersistentVariables.coins >= cost)
            {
                popupText.enabled = false;
                PersistentVariables.coins -= cost;
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
            popupText.enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inRange = false;
            popupText.enabled = false;
        }
    }
}
