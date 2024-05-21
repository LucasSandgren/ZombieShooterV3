using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewHealthBuff", menuName = "Inventory/Buffs/HealthBuff")]
public class HealthBuff : Buff
{
    public override void ApplyEffect(GameObject target)
    {
        PlayerHealth playerHealth = target.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.Heal((int)value);
        }
    }
}
