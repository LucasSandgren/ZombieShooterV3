using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayMoney : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyText;

    void Update()
    {
        moneyText.text = PersistentVariables.coins.ToString();
    }
}
