using System.Collections;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Vector3 offset; // OFFSET FOR CAMERA
    [SerializeField] public float damping; // HOW FAST CAMERA WILL FOLLOW PLAYER
    [SerializeField] private float shakeDuration; // DURATION OF CAMERA SHAKE
    [SerializeField] private float shakeIntensity; // SHAKE INTENSITY

    public Transform target;
    private Vector3 velocity = Vector3.zero;

    private void FixedUpdate()
    {
        Vector3 targetPos = target.position + offset;
        targetPos.z = -25f; // ENSURE ALWAYS -25 Z POS

        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, damping);
    }

    public void StartCameraShake()
    {
        StartCoroutine(CameraShake());
    }

    private IEnumerator CameraShake()
    {
        float elapsed = 0.0f;
        Vector3 originalPos = transform.position;
        originalPos.z = -25f; // ENSURE ALWAYS -25 Z POS

        while (elapsed < shakeDuration)
        {
            float x = Random.Range(-1f, 1f) * shakeIntensity;
            float y = Random.Range(-1f, 1f) * shakeIntensity;

            transform.position = new Vector3(originalPos.x + x, originalPos.y + y, -25f); // ENSURE ALWAYS -25 Z POS

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.position = new Vector3(originalPos.x, originalPos.y, -25f); // RESET ENSURE ALWAYS -25 Z POS
    }
}