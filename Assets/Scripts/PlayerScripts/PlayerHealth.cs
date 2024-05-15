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
    public Syringe syringe;


    private float immunityTimer;

    void Start()
    {
        currentHealth = PlayerPrefs.GetInt("Health");
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(currentHealth);
        syringe = GetComponent<Syringe>();
    }

    void Update()
    {
        immunityTimer -= Time.deltaTime;
    }

    public void TakeDamage(int damage)
    {
        //if(syringe.canTakeDamage == true)
        //{
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
            if (currentHealth <= 0)
            {
                currentHealth = 0;

                gameObject.SetActive(false);
                gameoverScreen.SetActive(true);
                Time.timeScale = 0;
                currentHealth = 100;
                Cursor.visible = true;
            }
        //}
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
    public int GetCurrentHealth()
    {
        return currentHealth;
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
