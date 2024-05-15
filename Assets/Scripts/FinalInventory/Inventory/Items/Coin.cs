using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, ICollectible
{
    public delegate void HandleCoinCollected(ItemData itemData);
    public static event HandleCoinCollected OnCoinCollected;
    public ItemData coinData;
    public void Collect()
    {
        Destroy(gameObject);
        OnCoinCollected?.Invoke(coinData);
    }
}
