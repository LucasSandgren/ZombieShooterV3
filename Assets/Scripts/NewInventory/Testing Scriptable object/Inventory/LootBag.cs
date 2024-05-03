using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBag : MonoBehaviour
{
    public GameObject droppedItemPrefab;
    public List<ItemData> lootList = new List<ItemData>();

    ItemData GetDroppedItem()
    {
        int randomNumber = Random.Range(1, 101); //Roll between 1 and 100
        List<ItemData> possibleItems = new List<ItemData>();
        foreach(ItemData item in lootList)
        {
            if(randomNumber <= item.dropChance)
            {
                possibleItems.Add(item);
            }
        }
        if(possibleItems.Count > 0)
        {
            ItemData droppedItem = possibleItems[Random.Range(0, possibleItems.Count)];
            return droppedItem;
        }
        return null;
    }
    public void InstantiateLoot(Vector3 spawnPosition)
    {
        ItemData droppedItem = GetDroppedItem();
        if(droppedItem != null)
        {
            GameObject itemDataObject = Instantiate(droppedItemPrefab, spawnPosition, Quaternion.identity);
            itemDataObject.GetComponent<SpriteRenderer>().sprite = droppedItem.icon;


            ////Extra
            //float dropForce = 300f;
            //Vector2 dropDirection = new Vector2(Random.Range(-1f,1f), Random.Range(-1f,1f));
            //itemDataObject.GetComponent<Rigidbody2D>().AddForce(dropDirection*dropForce, ForceMode2D.Impulse);

        }
    }
}
