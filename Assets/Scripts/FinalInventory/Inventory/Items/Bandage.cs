using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bandage : MonoBehaviour, ICollectible, IUsable
{
    public delegate void HandleBandageCollect(ItemData itemData);
    public static event HandleBandageCollect OnBandageCollect;
    public ItemData bandageData;
    public int healAmount;


    public void Collect()
    {
        Destroy(gameObject);
        OnBandageCollect?.Invoke(bandageData);
    }
    public void Use()
    {
        if (bandageData.itemBuff != null)
        {
            bandageData.itemBuff.ApplyEffect(GameObject.FindGameObjectWithTag("Player"));
            Inventory inventory = FindObjectOfType<Inventory>();
            inventory.Remove(bandageData);
        }
    }
}
