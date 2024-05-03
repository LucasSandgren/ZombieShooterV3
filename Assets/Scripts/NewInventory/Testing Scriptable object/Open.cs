using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<LootBag>().InstantiateLoot(transform.position);
        Destroy(gameObject);
    }

}
