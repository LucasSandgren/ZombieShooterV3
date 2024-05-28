using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayMoney : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private TextMeshProUGUI fuelText;

    // Update is called once per frame
    void Update()
    {
        moneyText.text = PersistentVariables.coins.ToString();
        //fuelText.text = Inventory.FuelTank.ToString();
    }
}
