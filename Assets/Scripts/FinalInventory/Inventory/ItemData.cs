using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Unity.UI;


[CreateAssetMenu]
public class ItemData : ScriptableObject
{
    public string displayName;
    public Sprite icon;
    public int dropChance;
    public Buff itemBuff;
    public ItemData(string lootName, int dropChance)
    {
        this.displayName = lootName;
        this.dropChance = dropChance;
    }
}
