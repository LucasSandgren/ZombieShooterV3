using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerHealth : MonoBehaviour
{
    private int maxHealth = 100;
    private float immunityDuration = 1;
    private int currentHealth;

    [Header("References: ")]
    [SerializeField] private Healthbar healthBar;
    [SerializeField] private GameObject gameoverScreen;
    private Syringe syringe;
    [SerializeField] SpriteRenderer spriteRenderer;

    private float immunityTimer;
    private bool isImmune = false;

    void Start()
    {
        currentHealth = PersistentVariables.currentHealth;
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(currentHealth);
        syringe = GetComponent<Syringe>();
    }

    void Update()
    {
        immunityTimer -= Time.deltaTime;
        if(immunityTimer <= 0)
        {
            isImmune = false;
            spriteRenderer.color = Color.white;
        }
        else
        {
            isImmune = true;
            spriteRenderer.color = Color.red;
        }
    }

    public void TakeDamage(int damage)
    {
        if (!isImmune)
        {
            Debug.Log("Immune");
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
    public int GetCurrentHealth()
    {
        return currentHealth;
    }
    public void SetImmunity(bool immune, float duration)
    {
        isImmune = immune;
        immunityDuration = duration;
        immunityTimer = duration;
        spriteRenderer.color = immune ? Color.red : Color.white;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        GameObject collisionObject = collision.gameObject;

        if (!isImmune)
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

        if (!isImmune)
        {
            if (collisionObject.CompareTag("Enviromental Hazard"))
            {
                TakeDamage(collisionObject.GetComponent<DamagingSpikes>().GetDamageValue());
                collisionObject.GetComponent<DamagingSpikes>().AnimateTrap();
                immunityTimer = immunityDuration;
            }
        }
    }
}
