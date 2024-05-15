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
    /* USED FOR PLAYER MODEL ANIMATION */
    [SerializeField] private Animator playerAnimator;

    IEnumerator ResetAnimationState()
    {
        yield return new WaitForSeconds(0.5f);
        playerAnimator.Play("Gun_Idle");
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
            playerAnimator.SetTrigger("Shoot");
            StartCoroutine(ResetAnimationState());

            //Clones a bullet at position of the gun + offset * transform.up to the offset independent of rotation, and then sets it active
            GameObject bulletInstance = Instantiate(bullet, gameObject.transform.position + spawnOffset * transform.right, gameObject.transform.rotation);
            bulletInstance.SetActive(true);
            Bullet bulletScript = bulletInstance.GetComponent<Bullet>();
            bulletScript.damage = damage;
            bulletScript.speed = bulletSpeed;
            bulletScript.timerUntilDestoyed = range / bulletScript.speed;

            //Starts the reload timer
            reloadTimer = 0;

            cameraMovement.StartCameraShake();
        }
    }
}
