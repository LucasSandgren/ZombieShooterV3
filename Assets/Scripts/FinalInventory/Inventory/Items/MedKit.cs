using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedKit : MonoBehaviour, ICollectible, IUsable
{
    public delegate void HandleMedKitCollected(ItemData itemData);
    public static event HandleMedKitCollected OnMedKitCollected;
    public ItemData medKitData;
    public int healAmount;
    private PlayerHealth playerHealth;
    private void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }
    public void Collect()
    {
        Destroy(gameObject);
        OnMedKitCollected?.Invoke(medKitData);
    }
    public void Use()
    {
        if(medKitData.itemBuff != null)
        {
            medKitData.itemBuff.ApplyEffect(GameObject.FindGameObjectWithTag("Player"));
            Inventory inventory = FindObjectOfType<Inventory>();
            inventory.Remove(medKitData);
        }
    }
}
