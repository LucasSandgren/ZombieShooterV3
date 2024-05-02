using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedKit : MonoBehaviour, ICollectible, IUsable
{
    public delegate void HandleCoinCollected(ItemData itemData);
    public ItemData medKitData;
    public int healAmount = 20;
    PlayerHealth playerHealth = new();
    public void Collect()
    {
        Destroy(gameObject);
    }
    public void Use()
    {
        playerHealth.Heal(healAmount);
    }
}
