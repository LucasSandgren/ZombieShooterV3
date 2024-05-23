using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBuff", menuName ="Inventory/Buff")]
public class Buff : ScriptableObject
{
    public string buffName;
    public string description;
    public float duration;
    public float value;

    public virtual void ApplyEffect(GameObject target)
    {
        Debug.Log($"Applying {buffName} to {target.name}");
    }
    public virtual void RemoveEffect(GameObject target)
    {
        Debug.Log($"Removing {buffName} from {target.name}");
    }
}
