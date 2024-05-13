using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Header("References: ")]
    public SceneFader sceneFader;
    [Header("Scene Management: ")]
    public string targetScene;


    void Start()
    {
        if (SceneFader.instance == null)
        {
            sceneFader = Instantiate(sceneFader);  // Only instantiate if no instance exists.
            SceneFader.instance = sceneFader;  // Ensure the instance is set correctly.
        }
        else
        {
            sceneFader = SceneFader.instance;  // Use the existing instance.
        }
    }
    public void ChangeScene()
    {
        switch (PlayerPrefs.GetInt("Level"))
        {
            case 0:
                PlayerPrefs.SetInt("Health", 100);
                sceneFader?.FadeToScene("Level_One");
                if (SceneFader.instance == null)
                {
                    Instantiate(sceneFader);
                }
                break;
            case 1:
                sceneFader?.FadeToScene("Level_Two");
                break;
            case 2:
                sceneFader?.FadeToScene("Level_Three");
                break;
            default:
                Debug.LogError("Invalid level");
                break;
        }
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level_One");
    }

    public void ToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("StartScreen");

    }

}
