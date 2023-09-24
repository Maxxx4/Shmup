using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCollision : MonoBehaviour
{
    private scoreManager scoreManager;
    private energyBarManager energyBar;
    public gameOver gameOver;
    public GameObject explosionAnimation;

    private void Start()
    {
        scoreManager = FindObjectOfType<scoreManager>();
        energyBar = FindObjectOfType<energyBarManager>();
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        //Check tag of colliding object and decrease energy accordingly
        if (collision.CompareTag("eBullet"))
        {
            Destroy(collision.gameObject);
            energyBar.IncreaseHeight(-0.40f);
        
        }
        if (collision.CompareTag("eEBullet"))
        {
            Destroy(collision.gameObject);
            energyBar.IncreaseHeight(-1f);
        
        }
        if (collision.CompareTag("Enemy"))
        {
            energyBar.IncreaseHeight(-0.5f);
        }

        //Score Decrease if energy bar is at 0;
        if (energyBar.currentHeight == 0)
        {
            if (collision.CompareTag("eBullet"))
            {
                Destroy(collision.gameObject);
                scoreManager.IncreaseScore(-5);
            
            }
            if (collision.CompareTag("eEBullet"))
            {
                Destroy(collision.gameObject);
                scoreManager.IncreaseScore(-20);
            
            }
            if (collision.CompareTag("Enemy"))
            {
                scoreManager.IncreaseScore(-10);
            }

            if(scoreManager.score == 0)
            {
                Destroy(gameObject);
                Destroy(collision.gameObject);
                Instantiate(explosionAnimation, transform.position, Quaternion.identity);
                gameOver.Setup();
            }
        }
    }
}
