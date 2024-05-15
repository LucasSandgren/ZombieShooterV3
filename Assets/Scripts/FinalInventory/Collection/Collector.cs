using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) //When a collision happens, collect the item (Destroy it and add the data to the inventory)
    {
        ICollectible collectible = collision.GetComponent<ICollectible>();
        if( collectible != null)
        {
            collectible.Collect();
        }
    }
}
