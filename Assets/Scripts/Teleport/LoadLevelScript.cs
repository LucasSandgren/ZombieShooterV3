using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelScript : MonoBehaviour
{
    public string LevelOne;
    //public string SettingsScreen;

    public SceneFader sceneFader;

    void Start()
    {
        sceneFader = FindObjectOfType<SceneFader>();
    }

    public void ChangeScene(string sceneName)
    {
        sceneFader.FadeToScene(sceneName);
    }
}
