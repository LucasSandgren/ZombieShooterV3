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
    [Header("Singleton")]
    public static LevelManager instance;


    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        if (SceneFader.instance == null)
        {
            SceneFader.instance = Instantiate(sceneFader);  // Only instantiate if no instance exists.
            DontDestroyOnLoad(SceneFader.instance.gameObject);
        }
    }

    public void SaveLastPosition(Vector3 pos, string scene)
    {
        lastPos = pos;
        lastScene = scene;
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
