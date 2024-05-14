using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Header("References: ")]
    public SceneFader sceneFader;
    [Header("Scene Management")]
    public string targetScene; 
    [Header("House teleportation")]
    public Vector3 lastPos;
    public string lastScene;
    private GameObject currentTeleporter;
    [Header("Singleton")]
    public static LevelManager instance;

    void Start()
    {
        sceneFader = SceneFader.instance;
    }

    public void SaveLastPosition(Vector3 pos, string scene)
    {
        lastPos = pos;
        lastScene = scene;
    }
    public void StartGame()
    {
        PlayerPrefs.SetInt("Health", 100);
        SceneManager.LoadScene("Level_One"); // TEMP FIX LOAD DIRECTLY INTO LEVEL ONE
        //sceneFader.FadeToScene("Level_One"); // "Coroutine couldn't be started because the the game object 'Fade' is inactive!" ERROR FADE SCREEN DON'T WORK FROM START SCREEN -> LEVEL_ONE FOR SOME REASON <.<
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
 