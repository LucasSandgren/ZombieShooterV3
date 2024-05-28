using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameLogicScript : MonoBehaviour
{
    [SerializeField] private GameObject winScreen;
    [SerializeField] private TextMeshProUGUI scoreText;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            winScreen.SetActive(true);
            Time.timeScale = 0;
            Cursor.visible = true;
        }
    }
}
