using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, ICollectible
{
    public delegate void HandleCoinCollected(ItemData itemData);
    public ItemData coinData;
    public void Collect()
    {
        Debug.Log("Coin has been collected");
        Destroy(gameObject);
    }
}
