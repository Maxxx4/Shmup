using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    public bullet bullet;
    Vector2 bulletDirection;

    [SerializeField]
    private float minHeight = 1.0f;
    [SerializeField]
    private float maxHeight = 5.0f;

    [SerializeField] public AudioSource shootSound;

    private bool isActive = false;

    private energyBarManager energyBar;

    private void Start()
    {
        energyBar = FindObjectOfType<energyBarManager>();
    }

    private void Update()
    {
        bulletDirection = (transform.localRotation * Vector2.up).normalized;
    }

    public void SetActive(float currentHeight)
    {
        //Activates weapon based on height of energy bar and range of activation
        if (currentHeight > minHeight && currentHeight <= maxHeight)
        {
            isActive = true;
        }
        else
        {
            isActive = false;
        }
    }

    public void Shoot()
    {
        //Instantiates bullet objects if weapon is active
        if (isActive)
        {
            shootSound.Play();
            GameObject shot = Instantiate(bullet.gameObject, transform.position, Quaternion.identity);
            bullet goShot = shot.GetComponent<bullet>();
            goShot.direction = bulletDirection;
        }
    }
}