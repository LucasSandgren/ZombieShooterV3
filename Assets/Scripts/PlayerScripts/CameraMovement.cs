using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform playerTransform;
    //public Transform fogFollow;

    [Header("Variables")]
    [SerializeField] private float shakeAmount;
    [SerializeField] private float shakeDuration;
    private float shakeTimer;


    private Vector3 newPosition;

    private float temporaryXOffset;
    private float temporaryYOffset;

    void Start()
    {
        newPosition.z = -10;
        shakeTimer = shakeDuration;
    }

    void Update()
    {
        //If camera should shake
        if (shakeTimer < shakeDuration)
        {
            temporaryXOffset = Random.Range(-1, 2) * shakeAmount;
            temporaryYOffset = Random.Range(-1, 2) * shakeAmount;

            shakeTimer += Time.deltaTime;
        }
        //Normal camera movement
        else
        {
            temporaryXOffset = 0;
            temporaryYOffset = 0;
        }

        newPosition.x = playerTransform.position.x + temporaryXOffset;
        newPosition.y = playerTransform.position.y + temporaryYOffset;

        transform.position = newPosition;
        //fogFollow.position = transform.position;
    }

    public void StartCameraShake()
    {
        shakeTimer = 0;
    }

    /* USED TO SWAP BETWEEN CAR AND PLAYER CAMERA */
    public void ChangeTarget(Transform newTarget)
    {
        playerTransform = newTarget;
    }
}
