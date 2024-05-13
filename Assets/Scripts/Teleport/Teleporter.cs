using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour
{
    [Header("House teleportation")]
    [Space]
    public string targetScene;
    [Header("References: ")]
    public SceneFader sceneFader;

    private void Awake()
    {
        if (sceneFader == null)
        {
            sceneFader = SceneFader.instance;
            if (sceneFader == null)
            {
                Debug.LogError("[Teleporter] SceneFader instance is not set.");
                return;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (SceneManager.GetActiveScene().name == "Level_One") // CHECK IF MAIN LEVEL
            { 
                Vector3 lastPos = other.transform.position;
                string lastScene = SceneManager.GetActiveScene().name;

                LevelManager.instance.SaveLastPosition(lastPos, lastScene);
                sceneFader.FadeToScene(targetScene);
            }
            else
            {
                if (!string.IsNullOrEmpty(LevelManager.instance.lastScene))
                {
                    sceneFader.FadeToScene(LevelManager.instance.lastScene, LevelManager.instance.lastPos);
                }
                else
                {
                    Debug.LogError("[Teleporter] lastScene is not set.");
                }
            }

            //sceneFader.FadeToScene(targetScene);
        }
    }
}
