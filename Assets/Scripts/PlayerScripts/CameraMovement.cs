using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Vector3 offset; // OFFSET FOR CAMERA
    [SerializeField] private float damping; // HOW FAST CAMERA WILL FOLLOW PLAYER
    [SerializeField] private float shakeDuration;
    [SerializeField] private float shakeIntensity;

    public Transform target;
    private Vector2 velocity = Vector2.zero;

    private void FixedUpdate()
    {
        Vector2 targetPos = target.position + offset;

        transform.position = Vector2.SmoothDamp(transform.position, targetPos, ref velocity, damping);
    }
    public void StartCameraShake()
    {
        StartCoroutine(CameraShake());
    }
    private IEnumerator CameraShake()
    {
        float elapsed = 0.0f;
        Vector3 originalPos = transform.position;

        while (elapsed < shakeDuration)
        {
            float x = Random.Range(-1f, 2f) * shakeIntensity;
            float y = Random.Range(-1f, 2f) * shakeIntensity;

            transform.position = new Vector3(originalPos.x + x, originalPos.y + y);

            elapsed += Time.deltaTime;

            yield return null;
        }
        transform.position = originalPos;
    }

}
