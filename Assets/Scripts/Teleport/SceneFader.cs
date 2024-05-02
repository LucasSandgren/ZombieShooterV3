using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    public Image fadePanel;
    public float fadeSpeed = 1.5f;

    void Start()
    {
            StartCoroutine(FadeIn());
    }

    
    public void FadeToScene(string sceneName)
    {
        StartCoroutine(FadeOut(sceneName));
    }

    IEnumerator FadeIn()
    {
        float alpha = fadePanel.color.a;
        while (alpha > 0)
        {
            alpha -= Time.deltaTime * fadeSpeed;
            fadePanel.color = new Color (0,0,0,alpha);
            yield return null;
        }
    }

    IEnumerator FadeOut(string sceneName)
    {
        float alpha = fadePanel.color.a;
        while (alpha < 1)
        {
            alpha += Time.deltaTime * fadeSpeed;
            fadePanel.color = new Color(0,0,0,alpha);
            yield return null;
        }
        SceneManager.LoadScene(sceneName);
        StartCoroutine(FadeIn());

    }
}
