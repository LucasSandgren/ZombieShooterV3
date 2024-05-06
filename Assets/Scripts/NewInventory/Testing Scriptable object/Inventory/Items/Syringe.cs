using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Syringe : MonoBehaviour, ICollectible, IUsable
{
    public delegate void HandleSyringeCollected(ItemData itemData);
    public static event HandleSyringeCollected OnSyringeCollected;
    public ItemData syringeData;
    public int speedAmount;
    public bool canTakeDamage;
    PlayerHealth playerHealth = new();
    public void Collect()
    {
        Destroy(gameObject);
        OnSyringeCollected?.Invoke(syringeData);
    }
    public void Use()
    {

    }
}
