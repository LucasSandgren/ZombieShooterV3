using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Healthbar : MonoBehaviour
{
    public Slider slider;
    public Image fillImage;
    public Color damageColor = Color.white;
    public float smoothSpeed = 0.1f;
    public float tintDuration = 0.2f;

    private Coroutine currentCoroutine;
    private Color originalColor;

    private void Start()
    {
        if (fillImage != null)
        {
            originalColor = fillImage.color;
        }
    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        if (currentCoroutine != null)
        {
            StopCoroutine(currentCoroutine);
        }
        currentCoroutine = StartCoroutine(SmoothHealthChange(health));
    }

    private IEnumerator SmoothHealthChange(int targetHealth)
    {
        float startHealth = slider.value;
        float elapsedTime = 0f;

        StartCoroutine(TintDamage());

        while (elapsedTime < smoothSpeed)
        {
            slider.value = Mathf.Lerp(startHealth, targetHealth, elapsedTime / smoothSpeed);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        slider.value = targetHealth;
    }

    private IEnumerator TintDamage()
    {
        fillImage.color = damageColor;

        yield return new WaitForSeconds(tintDuration);

        float elapsedTime = 0f;
        while (elapsedTime < tintDuration)
        {
            fillImage.color = Color.Lerp(damageColor, originalColor, elapsedTime / tintDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        fillImage.color = originalColor;
    }
}