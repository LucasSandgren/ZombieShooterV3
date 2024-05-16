using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour
{
    [Header("House teleportation")]
    [Space]
    [SerializeField] private Transform targetDestination;
    [SerializeField] private SceneFader sceneFader;
    private GameObject currentTeleporter;
    private CameraMovement cameraMovement;
    private float originalDamping;

    void Awake()
    {
        sceneFader = SceneFader.instance;
        cameraMovement = Camera.main.GetComponent<CameraMovement>();
        if (cameraMovement != null )
        {
            originalDamping = cameraMovement.damping;
        }
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
            if (cameraMovement != null)
            {
                cameraMovement.damping = 0;
            }
            yield return StartCoroutine(sceneFader.FadeOutLevel());
            transform.position = destination;
            yield return StartCoroutine(sceneFader.FadeInLevel());
            if (cameraMovement != null)
            {
                cameraMovement.damping = originalDamping;
            }
        }
    }

}