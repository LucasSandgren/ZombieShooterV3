using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Syringe : MonoBehaviour, ICollectible, IUsable
{
    public delegate void HandleSyringeCollected(ItemData itemData); //Honestly, not sure what a delegate is yet, although it is very usable while working with events
    public static event HandleSyringeCollected OnSyringeCollected; //And event that invokes/activates when the item gets collected
    public ItemData syringeData; //Where the scriptable object goes, references the data of the item
    public int speedAmount; //Adding speed when consumed
    public bool canTakeDamage = true; //Becomes invinsible for a short while when consumed
    float time = 0; //Just a timer
    public void Collect() //Collects the item using the OnCollected event
    {
        Destroy(gameObject);
        OnSyringeCollected?.Invoke(syringeData);
    }
    public void Use() //Uses the item
    {
        time += Time.deltaTime;
        while(time > 3)
        {
            canTakeDamage = false;
        }
    }
}
