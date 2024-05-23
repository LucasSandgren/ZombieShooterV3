using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : MonoBehaviour
{
    public delegate void HandleRifleCollected(ItemData itemData);
    public static event HandleRifleCollected OnRifleCollected;
    public ItemData rifleData;
    private void Start()
    {
        OnRifleCollected?.Invoke(rifleData);
    }


}
