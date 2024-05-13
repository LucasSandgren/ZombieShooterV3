using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnStart : MonoBehaviour
{
    [SerializeField] private GameObject InventorySlots;//Should get the parent of all the ItemSlots in the inventoryCanvas

    public static int coins;

    void Start()
    {
        Time.timeScale = 1;

        coins = PlayerPrefs.GetInt("Coins");

        for (int i = 0; i < InventorySlots.transform.childCount; i++)
        {
            ItemSlot itemSlot = InventorySlots.transform.GetChild(i).GetComponent<ItemSlot>();

            itemSlot.itemName = PlayerPrefs.GetString("ItemName" + i);
            itemSlot.quantity = PlayerPrefs.GetInt("ItemQuantity" + i);
            itemSlot.itemDescription = PlayerPrefs.GetString("ItemDescription" + i);
        }
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("StartScreen");
    }
}
