using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGame : MonoBehaviour
{
    private bool inRange = false;

    [Header("Variables: ")]
    [SerializeField] private string itemName;
    [SerializeField] private int itemCount;

    [Header("Refrences: ")]
    [SerializeField] private TextMeshProUGUI popupText;
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject player;


    private void Start()
    {
        popupText.enabled = false;
    }

    void Update()
    {
        if (inRange && Input.GetKeyDown(KeyCode.E))
        {
            if (itemCount == 0 || PersistentInventory.Instance.GetComponentInChildren<Inventory>().IsItemInInventory(itemName, itemCount))
            {
                player.SetActive(false);
                winScreen.SetActive(true);
                Time.timeScale = 0;
                Cursor.visible = true;
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
