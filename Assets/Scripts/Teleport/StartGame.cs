using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    //public string SettingsScreen;

    public SceneFader sceneFader;

    void Start()
    {
        sceneFader = FindObjectOfType<SceneFader>();
    }

    public void ChangeScene()
    {
        if (PlayerPrefs.GetInt("Level") == 0)
        {
            sceneFader.FadeToScene("Level_One");
        }

        else if (PlayerPrefs.GetInt("Level") == 1)
        {
            sceneFader.FadeToScene("Level_Two");
        }

        else if (PlayerPrefs.GetInt("Level") == 2)
        {
            sceneFader.FadeToScene("Level_Three");
        }
    }
}
