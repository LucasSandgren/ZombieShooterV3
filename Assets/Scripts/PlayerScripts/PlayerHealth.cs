using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    private int currentHealth;

    private float timerForHeal = 2.5f;

    public Healthbar healthBar;

    [SerializeField] private float immunityDuration;
    private float immunityTimer;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    void Update()
    {
        HealingIntervall();

        immunityTimer -= Time.deltaTime;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            //death animation
            //game over screen
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

    void HealingIntervall()
    {
        timerForHeal -= Time.deltaTime;
        if (timerForHeal <= 0)
        {
            timerForHeal = 2.5f;
            Heal(2);
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
                immunityTimer = immunityDuration;
            }
        }
    }
}