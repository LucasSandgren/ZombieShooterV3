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
        //SceneManager.LoadScene("Level_One"); 
        StartCoroutine(StartGameCoroutine());
        //sceneFader.FadeToScene("Level_One"); // "Coroutine couldn't be started because the the game object 'Fade' is inactive!" ERROR FADE SCREEN DON'T WORK FROM START SCREEN -> LEVEL_ONE FOR SOME REASON <.<
    }

    public void Restart()
    {
        //Debug.Log("Restart called");
        //Time.timeScale = 1;
        //ClearInventory();
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        StartCoroutine(RestartCoroutine());
    }

    public void ToMainMenu()
    {
        //Time.timeScale = 1;
        //ClearInventory() ;
        //SceneManager.LoadScene("StartScreen");
        StartCoroutine(ToMainMenuCoroutine());
    }
    private void ClearInventory()
    {
        //Inventory inventory = FindObjectOfType<Inventory>();
        //if(inventory != null)
        //{
        //    inventory.ClearInventory();
        //    inventory.ClearTanks();
        //}
        if (PersistentInventory.Instance != null && PersistentInventory.Instance.inventory != null)
        {
            PersistentInventory.Instance.inventory.ClearInventory();
            PersistentInventory.Instance.inventory.ClearTanks();
        }
    }
    private IEnumerator ToMainMenuCoroutine()
    {
        Time.timeScale = 1;

        // Optionally fade out the current scene
        if (sceneFader != null)
        {
            yield return sceneFader.FadeOutLevel();
        }

        ClearInventory();

        // Load the main menu scene
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("StartScreen");
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // Optionally fade in the new scene
        if (sceneFader != null)
        {
            yield return sceneFader.FadeInLevel();
        }
    }

    private IEnumerator StartGameCoroutine()
    {
        // Optionally fade out the current scene
        if (sceneFader != null)
        {
            yield return sceneFader.FadeOutLevel();
        }

        // Load the game scene
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Level_One");
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // Optionally fade in the new scene
        if (sceneFader != null)
        {
            yield return sceneFader.FadeInLevel();
        }

        // Ensure the inventory UI is drawn
        if (PersistentInventory.Instance != null && PersistentInventory.Instance.inventoryManager != null)
        {
            PersistentInventory.Instance.inventoryManager.DrawInventory(PersistentInventory.Instance.inventory.inventory);
        }
    }
    private IEnumerator RestartCoroutine()
    {
        Debug.Log("Restart called");
        Time.timeScale = 1;

        // Optionally fade out the current scene
        if (sceneFader != null)
        {
            yield return sceneFader.FadeOutLevel();
        }

        ClearInventory();

        // Load the game scene
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // Optionally fade in the new scene
        if (sceneFader != null)
        {
            yield return sceneFader.FadeInLevel();
        }

        // Ensure the inventory UI is drawn
        if (PersistentInventory.Instance != null && PersistentInventory.Instance.inventoryManager != null)
        {
            PersistentInventory.Instance.inventoryManager.DrawInventory(PersistentInventory.Instance.inventory.inventory);
        }
    }
}
 