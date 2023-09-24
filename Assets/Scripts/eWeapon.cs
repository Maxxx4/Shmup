using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eWeapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    private scoreManager scoreManager;

    Vector2 bulletDirection;

    public float shootInterval = 1.0f;
    public float delayBeforeFirstShot = 0.0f;

    public bool isActive = false;
    public bool shootAtPlayer = false;

    public int scoreCap = -1;

    private Transform playerTransform;
    private float lastShootTime;
    private bool hasShot;

    [SerializeField] public AudioSource shootSound;

    private void Start()
    {
        scoreManager = FindObjectOfType<scoreManager>();
        hasShot = false;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {   
        //Adds delay to weapons before shooting
        if(transform.position.y <= 10f && hasShot == false)
        {
            hasShot = true;
            lastShootTime = Time.time + delayBeforeFirstShot;
        }

        //Shoot weapons
        if(transform.position.y <= 5f && playerTransform != null)
        {
            if(isActive)
            {
                if (Time.time - lastShootTime >= shootInterval && scoreManager.score >= scoreCap)
                {
                    Shoot();
                    shootSound.Play();
                }
            }
        }
    }

    private void Shoot()
    {
        lastShootTime = Time.time;

        GameObject newBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet bulletComponent = newBullet.GetComponent<bullet>();
         
            if (shootAtPlayer)
            {
                Vector2 directionToPlayer = (playerTransform.position - transform.position);
                Vector2 normalizedDirection = directionToPlayer.normalized;
                bulletComponent.direction = normalizedDirection * bulletComponent.speed;
                
                //Calculate the rotation based on bullet's direction
                float angle = Mathf.Atan2(bulletComponent.direction.y, bulletComponent.direction.x) * Mathf.Rad2Deg + 90f;

                //Apply the rotation to bullet's transform
                bulletComponent.transform.rotation = Quaternion.Euler(0f, 0f, angle);
            }
            else
            {
                bulletComponent.direction = Vector2.down;
                bulletComponent.transform.rotation = Quaternion.Euler(0f, 0f, -90f);
            }
    }
}