using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public Vector2 direction = new Vector2(0, 1);
    public float speed = 2;

    public bool shouldExplode = false; //Flag to determine if the bullet should explode
    public float explosionTime = 2.0f; //Time before the bullet explodes
    public GameObject explosionBulletPrefab; //Prefab for the bullets that instantiate when bullet explodes
    public float explosionBulletSpeed = 3.0f; //Speed of the bullets from explosion

    private float explosionStartTime;
    private bool exploded = false;

    void Start()
    {

        if (shouldExplode)
        {
            explosionStartTime = Time.time;
        }
    }

    void Update()
    {
        if (shouldExplode && !exploded && Time.time - explosionStartTime >= explosionTime)
        {
            Explode();
        }
    }

    private void FixedUpdate()
    {
        //Setting bounds for bullets to stay within play space
        Vector2 pos = transform.position;
        pos += direction * speed * Time.fixedDeltaTime;
        transform.position = pos;

        if(pos.y >= 5f || pos.y <= -7 || pos.x >= 4.3f || pos.x <= -4.9f)
        {
            Destroy(gameObject);
        }

    }

    private void Explode()
    {
        exploded = true;
        
        //Instantiate 8 bullets going in 8 different directions when the bullet explodes
        for (int i = 0; i < 8; i++)
        {
            float angle = i * 45.0f;
            Quaternion rotation = Quaternion.Euler(0, 0, angle);
            Vector2 direction = rotation * Vector2.up;

            GameObject explosionBullet = Instantiate(explosionBulletPrefab, transform.position, rotation);
            bullet bulletComponent = explosionBullet.GetComponent<bullet>();

                bulletComponent.direction = rotation * Vector2.right;
                bulletComponent.speed = explosionBulletSpeed;
        }

        Destroy(gameObject);
    }
}

