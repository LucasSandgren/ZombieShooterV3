using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagingSpikes : MonoBehaviour
{
    [SerializeField] private int damage;

    [SerializeField] private Animator trapAnimator;

    public void AnimateTrap()
    {
        trapAnimator.SetTrigger("Collision");
    }
    public int GetDamageValue()
    {
        return damage;
    }
}
