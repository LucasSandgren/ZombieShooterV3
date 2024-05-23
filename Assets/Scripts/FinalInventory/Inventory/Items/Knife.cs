using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{

    public delegate void HandleKnifeCollected(ItemData itemData);
    public static event HandleKnifeCollected OnKnifeCollected;
    public ItemData knifeData;
    private void Awake()
    {
        OnKnifeCollected?.Invoke(knifeData);
    }
}
