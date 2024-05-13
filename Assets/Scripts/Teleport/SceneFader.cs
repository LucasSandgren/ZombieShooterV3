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
        //if (instance != null && instance != this) 
        //{
        //    Destroy(gameObject);
        //}
        //else
        //{
            instance = this;
            DontDestroyOnLoad(gameObject);
        //}

        /* THE SCENE FADER IS REMOVED FROM TELEPORTS BETWEEN SCENES PREVENTING TELEPORT IF I DESTROY OBJECT BETWEEN SCENE, BUT THE FADE IS NOT SUPPOSED TO BE REMOVED */
    }
    void Start()
    {
            StartCoroutine(FadeIn());
    }

    public void FadeToScene(string sceneName)
    {
        if (instance == null)
        {
            Debug.LogError("[SceneFader] Instance is null when trying to fade to " + sceneName);
            return;
        }
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
