using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagingSpikes : MonoBehaviour
{
    public Animator trapAnimator;
    public int damage; 

    public void AnimateTrap()
    {
        trapAnimator.SetTrigger("Collision");
    }
}
