using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    private bool inRange = false;

    [Header("Variables: ")]
    [SerializeField] private string nextLevelName;
    [SerializeField] private string itemName;
    [SerializeField] private int itemCount;

    [Header("Refrences: ")]
    [SerializeField] private Inventory inventoryScript;
    [SerializeField] private PlayerHealth playerHealthScript;
    [SerializeField] private TextMeshProUGUI popupText;

    private void Start()
    {
        popupText.enabled = false;
    }

    void Update()
    {
        if (inRange && Input.GetKeyDown(KeyCode.E))
        {
            if (itemCount == 0 || inventoryScript.IsItemInInventory(itemName, itemCount))
            {
                PersistentVariables.currentHealth = playerHealthScript.GetCurrentHealth();
                SceneManager.LoadScene(nextLevelName);
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
