using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedKit : MonoBehaviour, ICollectible, IUsable
{
    public delegate void HandleMedKitCollected(ItemData itemData);
    public static event HandleMedKitCollected OnMedKitCollected;
    public ItemData medKitData;
    public int healAmount = 20;
    PlayerHealth playerHealth = new();
    public void Collect()
    {
        Destroy(gameObject);
        OnMedKitCollected?.Invoke(medKitData);
    }
    public void Use()
    {
        playerHealth.Heal(healAmount);
    }
}
