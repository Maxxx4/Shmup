using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletCollision : MonoBehaviour
{
    public GameObject explosionAnimation;
    private scoreManager scoreManager;
    private energyBarManager energyBar;

    public int scoreIncreaseBy;
    public float heightIncreaseBy;
    public float hP = 1;

    private void Start()
    {
        scoreManager = FindObjectOfType<scoreManager>();
        energyBar = FindObjectOfType<energyBarManager>();
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {  
        //Decrease hp when hit, destroy object and increase score and energy bar height when hp is equal to 0
        if (collision.CompareTag("Bullet"))
        {
            hP -= 1;
            Destroy(collision.gameObject);

            if(hP == 0)
            {

                Destroy(gameObject);
                Destroy(collision.gameObject);
                Instantiate(explosionAnimation, transform.position, Quaternion.identity);

                scoreManager.IncreaseScore(scoreIncreaseBy);

                energyBar.IncreaseHeight(heightIncreaseBy);
            }
        
        }
    }
}
