using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour
{
    [Header("House teleportation")]
    [Space]
    [SerializeField] private Transform targetDestination;

    private GameObject currentTeleporter;
    [SerializeField] private SceneFader sceneFader;

    void Awake()
    {
        sceneFader = SceneFader.instance;
    }

    public Transform GetDestination()
    {
        return targetDestination;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentTeleporter != null)
            {
                Debug.Log("Teleporting to: " + currentTeleporter.GetComponent<Teleporter>().GetDestination().position);
                StartCoroutine(TeleportFade(currentTeleporter.GetComponent<Teleporter>().GetDestination().position));
            }
            else
            {
                Debug.Log("No current teleporter set.");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            currentTeleporter = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            if (collision.gameObject == currentTeleporter)
            {
                currentTeleporter = null;
                Debug.Log("Current teleporter cleared.");
            }
        }
    }
    IEnumerator TeleportFade(Vector3 destination)
    {
        if (sceneFader != null)
        {
            yield return StartCoroutine(sceneFader.FadeOutLevel());
            transform.position = destination;
            yield return StartCoroutine(sceneFader.FadeInLevel());
        }
    }

}