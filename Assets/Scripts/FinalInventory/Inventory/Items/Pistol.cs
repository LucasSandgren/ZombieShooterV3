using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    public delegate void HandlePistolCollected(ItemData itemData);
    public static event HandlePistolCollected OnPistolCollected;
    public ItemData pistolData;
    private void Awake()
    {
        OnPistolCollected?.Invoke(pistolData);
    }
}
