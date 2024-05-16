using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnStart : MonoBehaviour
{
    //[SerializeField] private GameObject InventorySlots;//Should get the parent of all the ItemSlots in the inventoryCanvas
    [Header("Character Stats: ")]
    public static int coins;

    [Header("References: ")]
    [SerializeField] private Inventory inventoryScript;

    void Start()
    {
        
        Time.timeScale = 1;

        coins = PlayerPrefs.GetInt("Coins");
        //inventoryScript.LoadInventoryFromPlayerPrefs(inventoryScript);

        //Loops 13 times since that is the max amount of items that can be saved
        for (int i = 0; i < 13; i++)
        {
            if (PlayerPrefs.HasKey(PlayerPrefs.GetString("ItemName" + i)))
            {
                //Creates a new "ItemData" with the saved name for slot i
                ItemData loadedItem = new ItemData(PlayerPrefs.GetString("ItemName" + i), 0);

                //Adds the item as many times as is saved
                for (int j = 0; j < PlayerPrefs.GetInt("ItemQuantity" + j); j++)
                {
                    inventoryScript.Add(loadedItem);
                }
            }

        }
    }
    void OnStart2() //Not the used method, simply for testing saving between scenes
    {
        for (int i = 0; i < 13; i++)
        {
            if (PlayerPrefs.HasKey("ItemName" + i))
            {
                // Creates a new "ItemData" with the saved name for slot i
                ItemData loadedItem = new ItemData(PlayerPrefs.GetString("ItemName" + i), 0);

                // Adds the item as many times as is saved
                for (int j = 0; j < PlayerPrefs.GetInt("ItemQuantity" + i); j++)
                {
                    inventoryScript.Add(loadedItem);
                }
            }
        }
    }

}
