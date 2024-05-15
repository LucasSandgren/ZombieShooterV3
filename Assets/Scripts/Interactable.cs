using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interactable : MonoBehaviour
{
    private bool inRange = false;

    [Header("Remove object with money: ")]
    [SerializeField] private bool payToOpen;
    [SerializeField] private int cost = 0;

    [Header("Go to another level: ")]
    [SerializeField] private bool toNextLevel;
    [SerializeField] private string nextLevelName;

    [Header("Check for items and then go to next level: ")]
    [SerializeField] private bool useItemForNextLevel;
    [SerializeField] private string itemName;
    [SerializeField] private int itemCount;
    //[SerializeField] private InventoryManagerScript inventoryScript;

    [Header("Refrences needed to switch level: ")]
    [SerializeField] private GameObject InventorySlots;//Should get the parent of all the ItemSlots in the inventoryCanvas
    [SerializeField] private PlayerHealth playerHealthScript;

    //[Header("Driving: ")]
    //[SerializeField] private GameObject car;
    //private bool drivingCar = false;


    private void Update()
    {
        if (inRange && Input.GetKeyDown(KeyCode.E))
        {
            HandleInterraction();
        }
        //if (inRange && Input.GetKeyDown(KeyCode.H))
        //{
        //    if (!drivingCar)
        //    {
        //        DriveCar();
        //    }
        //    //if (drivingCar)
        //    //{
        //    //    LeaveCar();
        //    //}
        //}
    }

    private void HandleInterraction()
    {
        if (payToOpen)
        {
            PayToOpen();
        }
        else if (toNextLevel)
        {
            GoToNextLevel();
        }
        else if (useItemForNextLevel)
        {
            UseItemToNextLevel();
        }
    }
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

    private void PayToOpen()
    {
        if (OnStart.coins >= cost)
        {
            OnStart.coins -= cost;
            Destroy(gameObject);
        }
    }

    private void GoToNextLevel()
    {
        //PlayerPrefs.SetInt("Health", playerHealthScript.GetCurrentHealth());
        //PlayerPrefs.SetInt("Coins", OnStart.coins);
        //PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);

        //for (int i = 0; i < InventorySlots.transform.childCount; i++)
        //{
        //    InventorySlot itemSlot = InventorySlots.transform.GetChild(i).GetComponent<InventorySlot>();

        //    PlayerPrefs.SetString("ItemName" + i, itemSlot.name);
        //    PlayerPrefs.SetInt("ItemQuantity" + i, itemSlot.qua);
        //    PlayerPrefs.SetString("ItemDescription" + i, itemSlot.itemDescription);
        //}

        SceneManager.LoadScene(nextLevelName);
    }

    private void UseItemToNextLevel()
    {
        //if (CountNumberOfItem() >= itemCount)
        //{
        //    //PlayerPrefs.SetInt("Health", playerHealthScript.GetCurrentHealth());
        //    //PlayerPrefs.SetInt("Coins", OnStart.coins);
        //    //PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);

        //    //for (int i = 0; i < InventorySlots.transform.childCount; i++)
        //    //{
        //    //    ItemSlot itemSlot = InventorySlots.transform.GetChild(i).GetComponent<ItemSlot>();

        //    //    PlayerPrefs.SetString("ItemName" + i, itemSlot.itemName);
        //    //    PlayerPrefs.SetInt("ItemQuantity" + i, itemSlot.quantity);
        //    //    PlayerPrefs.SetString("ItemDescription" + i, itemSlot.itemDescription);
        //    //}

        //    SceneManager.LoadScene(nextLevelName);
        //}
    }
    //public int CountNumberOfItem()
    //{
    //    int currentItemCount = 0;

    //    for (int i = 0; i < inventoryScript.itemSlot.Length - 1; i++)
    //    {
    //        if (inventoryScript.itemSlot[i].itemName == itemName)
    //        {
    //            currentItemCount += inventoryScript.itemSlot[i].quantity;
    //        }
    //    }

    //    return currentItemCount;
    //}
    //private void DriveCar()
    //{
    //    if (OnStart.coins >= cost)
    //    {
    //        OnStart.coins -= cost;
    //        GameObject player = GameObject.FindGameObjectWithTag("Player");
    //        Driving driving = car.GetComponent<Driving>();
    //        if (player != null)
    //        {
    //            player.SetActive(false);
    //            car.SetActive(true);
    //            car.GetComponent<Driving>().enabled = true;
    //            driving.isActive = true;
    //            drivingCar = true;
    //            HideCrosshair();
    //            Camera.main.GetComponent<CameraMovement>().ChangeTarget(car.transform); // SET CAMERA FOLLOW TO CAR

    //        }


    //    }
    //}
    //private void HideCrosshair()
    //{
    //    GameObject crosshair = GameObject.FindGameObjectWithTag("Crosshair");
    //    crosshair.SetActive(false);

    //}
    //private void ShowCrosshair()
    //{
    //    GameObject crosshair = GameObject.FindGameObjectWithTag("Crosshair");
    //    crosshair.SetActive(true);
    //}
    //private void LeaveCar()
    //{
    //    GameObject player = GameObject.FindGameObjectWithTag("Player");
    //    Driving driving = car.GetComponent<Driving>();

    //    if (player != null)
    //    {
    //        player.SetActive(true);
    //    }
    //    car.SetActive(false);
    //    car.GetComponent<Driving>().enabled = false;
    //    drivingCar = false;
    //    Camera.main.GetComponent<CameraMovement>().ChangeTarget(player.transform); // CHANGE BACK TO CAMERA FOLLOWING PLAYER
    //    ShowCrosshair();
    //}
}
