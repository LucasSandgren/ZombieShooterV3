using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    
    public string targetScene;
    public SceneFader sceneFader;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            sceneFader.FadeToScene(targetScene);
        }
    }
}
