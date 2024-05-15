using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : MonoBehaviour
{
    [Header("Contains: ")]
    [SerializeField] private KeyCode interactionKey = KeyCode.C;
    
    [Header("References: ")]
    [SerializeField] private Animator animator;
    private Transform player;
    [SerializeField] private BoxCollider2D collider;
    [SerializeField] private GameObject XXY;
    [SerializeField] private GameObject YYZ;
    [SerializeField] private GameObject ZZX;

    [Header("Details: ")]
    [SerializeField] private bool mouseOver = false;
    

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    
    void Update()
    {
        if (mouseOver && Input.GetKeyDown(interactionKey) && IsInRange()) 
        {
            Debug.Log("OPENING");
            _OpenChest();
        }
    }
    private void OnMouseEnter()
    {
        mouseOver = true;
    }

    private void OnMouseExit()
    {
        mouseOver = false;
    }
    private void _OpenChest()
    {
        animator.SetTrigger("Open");
        
        StartCoroutine(SpawnLoot());
    }

    private bool IsInRange()
    {
        float distance = Vector2.Distance(player.position, transform.position);
        return distance <= collider.size.x / 2f;
    }

    private IEnumerator SpawnLoot()
    {
        const int numOfLoot = 3;
        const float spawnInterval = 0.2f;
        Vector3 spawnPos = transform.position + new Vector3(0, 0.5f, 0);

        for (int i = 0; i < numOfLoot; i++)
        {
            GameObject loot = Instantiate(XXY, spawnPos, Quaternion.identity);
            Rigidbody2D lootRB = loot.GetComponent<Rigidbody2D>();
            float hForce = Random.Range(-1f, 1f);
            float vForce = 1f;

            lootRB.AddForce(new Vector2(hForce, vForce), ForceMode2D.Impulse);
            yield return new WaitForSeconds(spawnInterval);
        }
    }

}
