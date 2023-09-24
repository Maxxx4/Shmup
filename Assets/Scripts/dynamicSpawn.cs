using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dynamicSpawn : MonoBehaviour
{
    private scoreManager scoreManager;
    private SpriteRenderer spriteRenderer;
    private bool spawned;
    
    public Color newColor;
    public int spawnCap;
    void Start()
    {
        scoreManager = FindObjectOfType<scoreManager>();

        //Change enemy color to show that its a special enemy
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = newColor;

        spawned = false;
    }
    void FixedUpdate()
    {
        //If enemy does not meet the necessary spawn cap, destroy it before it shows up on the players screen
        Vector2 pos = transform.position;
        pos = transform.position;

        if(scoreManager.score < spawnCap && pos.y <= 5.5f && spawned == false)
        {
            Destroy(gameObject);
        }

        if(pos.y <= 5.5f && spawned == false)
        {
            spawned = true;
        }

    }
}
