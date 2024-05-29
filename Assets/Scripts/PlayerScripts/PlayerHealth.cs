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
    [SerializeField] private GameObject gameOverScreen;
    private Syringe syringe;
    [SerializeField] private Renderer renderer;


    private Color originalColor;

    private float immunityTimer;
    private bool isImmune = false;

    void Start()
    {
        currentHealth = PersistentVariables.currentHealth;
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(currentHealth);
        syringe = GetComponent<Syringe>();
        originalColor = renderer.material.color;
    }

    void Update()
    {
        immunityTimer -= Time.deltaTime;
        if (immunityTimer <= 0)
        {
            isImmune = false;
            //renderer.material.color = Color.white;
        }
        else
        {
            isImmune = true;
            //renderer.material.color = Color.cyan;
        }
        //if(isImmune == true)
        //{
        //    StartCoroutine(FlickerImmunity());
        //}
    }

    public void TakeDamage(int damage)
    {
        if (isImmune == false)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
            immunityTimer = immunityDuration;
            StartCoroutine(Flicker());
            if (currentHealth <= 0)
            {
                currentHealth = 0;

                gameObject.SetActive(false);
                gameOverScreen.SetActive(true);
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
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        GameObject collisionObject = collision.gameObject;

        if (isImmune == false)
        {
            if (collisionObject.CompareTag("Zombie"))
            {
                TakeDamage(collisionObject.GetComponent<ZombieAttack>().attackDamage);
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        GameObject collisionObject = collision.gameObject;

        if (isImmune == false)
        {
            if (collisionObject.CompareTag("Enviromental Hazard"))
            {
                TakeDamage(collisionObject.GetComponent<DamagingSpikes>().GetDamageValue());
                collisionObject.GetComponent<DamagingSpikes>().AnimateTrap();
            }
        }
    }
    private IEnumerator Flicker()
    {
        int flicker = 3;
        float duration = .2f;

        for (int i = 0; i < flicker; i++)
        {
            renderer.material.color = Color.red;
            yield return new WaitForSeconds(duration);
            renderer.material.color = Color.white;
            yield return new WaitForSeconds(duration);
        }
    }
    //private IEnumerator FlickerImmunity()
    //{
    //    int flicker = 5;
    //    for (int i = 0;i < flicker;i++)
    //    {
    //        renderer.material.color = Color.cyan;
    //        yield return new WaitForSeconds(0.3f);
    //        renderer.material.color = Color.white;
    //        yield return new WaitForSeconds(0.3f);
    //    }
    //}
}
