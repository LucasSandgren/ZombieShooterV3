using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerHealth : MonoBehaviour
{
    [Header("Character Stats: ")]
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private float immunityDuration;
    private int currentHealth;

    [Header("References: ")]
    public Healthbar healthBar;
    public GameObject gameoverScreen;


    private float immunityTimer;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        immunityTimer -= Time.deltaTime;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            currentHealth = 0;

            gameObject.SetActive(false);
            gameoverScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Heal(int health)
    {
        currentHealth += health;
        healthBar.SetHealth(currentHealth);
        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
            //heal animation
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        GameObject collisionObject = collision.gameObject;

        if (immunityTimer <= 0)
        {
            if (collisionObject.CompareTag("Zombie"))
            {
                TakeDamage(collisionObject.GetComponent<ZombieAttack>().attackDamage);
                immunityTimer = immunityDuration;
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        GameObject collisionObject = collision.gameObject;

        if (immunityTimer <= 0)
        {
            if (collisionObject.CompareTag("Enviromental Hazard"))
            {
                TakeDamage(collisionObject.GetComponent<DamagingSpikes>().damage);
                collisionObject.GetComponent<DamagingSpikes>().AnimateTrap();
                immunityTimer = immunityDuration;
            }
        }
    }
}
