using System.Collections;
using System.Collections.Generic;
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

    void Update()
    {
        if (inRange && Input.GetKeyDown(KeyCode.E))
        {
            if (inventoryScript.IsItemInInventory(itemName, itemCount))
            {
                //Saves everything
                //PlayerPrefs.SetInt("Health", playerHealthScript.GetCurrentHealth());
                //PlayerPrefs.SetInt("Coins", OnStart.coins);
                //PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);

                //for (int i = 0; i < InventorySlots.transform.childCount; i++)
                //{
                //    ItemSlot itemSlot = InventorySlots.transform.GetChild(i).GetComponent<ItemSlot>();

                //    PlayerPrefs.SetString("ItemName" + i, itemSlot.itemName);
                //    PlayerPrefs.SetInt("ItemQuantity" + i, itemSlot.quantity);
                //    PlayerPrefs.SetString("ItemDescription" + i, itemSlot.itemDescription);
                //}

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
