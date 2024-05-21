using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewImmunityBuff", menuName = "Inventory/Buffs/ImmunityBuff")]
public class ImmunityBuff : Buff
{
    public override void ApplyEffect(GameObject target)
    {
        PlayerHealth playerHealth = target.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.SetImmunity(true, duration);
        }
    }

    public override void RemoveEffect(GameObject target)
    {
        PlayerHealth playerHealth = target.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.SetImmunity(false, 0);
        }
    }
}