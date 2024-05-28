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
        SceneManager.LoadScene("Level_One"); 
        //sceneFader.FadeToScene("Level_One"); // "Coroutine couldn't be started because the the game object 'Fade' is inactive!" ERROR FADE SCREEN DON'T WORK FROM START SCREEN -> LEVEL_ONE FOR SOME REASON <.<
    }

    public void Restart()
    {
        Debug.Log("Restart called");
        Time.timeScale = 1;
        ClearInventory();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ToMainMenu()
    {
        Time.timeScale = 1;
        ClearInventory() ;
        SceneManager.LoadScene("StartScreen");
    }
    private void ClearInventory()
    {
        Inventory inventory = FindObjectOfType<Inventory>();
        if(inventory != null)
        {
            inventory.ClearInventory();
            inventory.ClearTanks();
        }
    }
}
 