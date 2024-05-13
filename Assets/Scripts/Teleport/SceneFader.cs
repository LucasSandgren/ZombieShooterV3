using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    public Image fadePanel;
    public float fadeOutSpeed = 1f;
    public float fadeInSpeed = 1f;

    public static SceneFader instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(transform.root.gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject); // DESTROY IF EXIST
        }
    }
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
            alpha -= Time.deltaTime * fadeInSpeed;
            fadePanel.color = new Color (0,0,0,alpha);
            yield return null;
        }
    }

    IEnumerator FadeOut(string sceneName)
    {
        float alpha = fadePanel.color.a;
        while (alpha < 1)
        {
            alpha += Time.deltaTime * fadeOutSpeed;
            fadePanel.color = new Color(0,0,0,alpha);
            yield return null;
        }
        SceneManager.LoadScene(sceneName);
        StartCoroutine(FadeIn());

    }
    
}
