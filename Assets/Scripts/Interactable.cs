using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interactable : MonoBehaviour
{
    //    OLD CODE
    //    SHOULD BE REMOVED
    //    STILL HAS DRIVING CODE THAT MAY BE WANTED



    private bool inRange = false;

    //[Header("Driving: ")]
    //[SerializeField] private GameObject car;
    //private bool drivingCar = false;


    private void Update()
    {
        if (inRange && Input.GetKeyDown(KeyCode.E))
        {

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
