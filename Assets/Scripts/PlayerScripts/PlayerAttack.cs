using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private GameObject bullet;
    private CameraMovement cameraMovement;

    private float spawnOffset;

    [Header("Variables: ")]
    private float reloadTimer;
    [SerializeField] private float reloadTime;

    [SerializeField] private int damage;
    [SerializeField] private float range;
    [SerializeField] private float bulletSpeed;

    [Header("References: ")]
    [Header("Audio")]
    [SerializeField] private AudioSource audio;
    [SerializeField] private float volume;
    [Header("Muzzle Flash")]
    [SerializeField] private GameObject muzzlePrefab;


    IEnumerator ResetAnimationState()
    {
        yield return new WaitForSeconds(0.5f);
    }
    void Start()
    {
        cameraMovement = Camera.main.GetComponent<CameraMovement>();

        //The secnond child of the weapon should be its bullet
        bullet = transform.GetChild(1).gameObject;

        //Calculates the offset needed so that the bullet can get cloned at its edge not center (to avoid the bullet overlapping with the player when its being fired)
        spawnOffset = (bullet.transform.lossyScale.y / 2);

    }

    void Update()
    {
        reloadTimer += Time.deltaTime;

        if (Input.GetMouseButton(0) && reloadTimer >= reloadTime)
        {
            StartCoroutine(ResetAnimationState());

            //Clones a bullet at position of the gun + offset * transform.up to the offset independent of rotation, and then sets it active
            GameObject bulletInstance = Instantiate(bullet, gameObject.transform.position + spawnOffset * transform.right, gameObject.transform.rotation);
            bulletInstance.SetActive(true);
            Bullet bulletScript = bulletInstance.GetComponent<Bullet>();
            bulletScript.damage = damage;
            bulletScript.speed = bulletSpeed;
            bulletScript.timerUntilDestoyed = range / bulletScript.speed;
            Quaternion muzzleFlashRotation = gameObject.transform.rotation * Quaternion.Euler(0, 180, 0);
            GameObject muzzleFlashInstance = Instantiate(muzzlePrefab, gameObject.transform.position + (spawnOffset + .75f) * transform.right, muzzleFlashRotation);
            Destroy(muzzleFlashInstance, 0.1f);

            //Starts the reload timer
            reloadTimer = 0;
            PlaySound(volume);

            cameraMovement.StartCameraShake();
        }
    }

    private void PlaySound(float volume)
    {
        //if (sounds.Length == 0) return;

        audio.volume = volume;
        audio.Play();
        
    }
}
