using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FuelTank : MonoBehaviour, ICollectible
{
    public delegate void HandleFuelTankCollected(ItemData itemData);
    public static HandleFuelTankCollected OnFuelTankCollected;
    public ItemData itemData;
    public void Collect()
    {
        Destroy(gameObject);
        OnFuelTankCollected?.Invoke(itemData);
    }
}
