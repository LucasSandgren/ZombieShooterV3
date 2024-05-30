using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentInventory : MonoBehaviour
{
    public static PersistentInventory Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}