using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetProgress : MonoBehaviour
{
    public void ResetProg()
    {
        PlayerPrefs.SetInt("Health", 100);
        PlayerPrefs.SetInt("Coins", 0);
        PlayerPrefs.SetInt("Level", 0);

        for (int i = 0; i < 13; i++)
        {
            PlayerPrefs.DeleteKey("ItemName" + i);
            PlayerPrefs.DeleteKey("ItemQuantity" + i);
        }
    }
}
