using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    [Header("Fade times: ")]
    public Image fadePanel;
    public float fadeOutSpeed = 1f;
    public float fadeInSpeed = 1f;
    [Space]

    [Header("Singleton")]
    public static SceneFader instance;

    private GameObject player;
    

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

        player = GameObject.FindGameObjectWithTag("Player");
        
    }
    void Start()
    {
        fadePanel.gameObject.SetActive(true);
        StartCoroutine(FadeIn());
    }

    public void FadeToScene(string sceneName)
    {
        if (!fadePanel.gameObject.activeSelf)
        {
            fadePanel.gameObject.SetActive(true); // Ensure fadePanel is active before starting coroutine
        }
        StartCoroutine(FadeOut(sceneName));
    }

    IEnumerator FadeIn() // BETWEEN SCENES
    {
        yield return FadeInLevel();
    }

    IEnumerator FadeOut(string sceneName) // BETWEEN SCENES
    {
        yield return FadeOutLevel();
        SceneManager.LoadScene(sceneName);
        yield return new WaitForEndOfFrame();
        StartCoroutine(FadeIn());

    }
    public IEnumerator FadeInLevel()
    {
        float alpha = fadePanel.color.a;
        while (alpha > 0)
        {
            alpha -= Time.deltaTime * fadeInSpeed;
            fadePanel.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
    }
    public IEnumerator FadeOutLevel()
    {
        float alpha = fadePanel.color.a;
        while (alpha < 1)
        {
            alpha += Time.deltaTime * fadeOutSpeed;
            fadePanel.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
    }
    
}
