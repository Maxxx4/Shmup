using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class player : MonoBehaviour
{

    float moveSpeed = 5;

    weapon[] weapons;

    private float nextFireTime = 0;
    public float cooldownDuration = 0.5f;


    bool moveUp;
    bool moveDown;
    bool moveLeft;
    bool moveRight;

    private scoreManager scoreManager;
    private energyBarManager energyBar;
    void Start()
    {
        weapons = transform.GetComponentsInChildren<weapon>();
        scoreManager = FindObjectOfType<scoreManager>();
        energyBar = FindObjectOfType<energyBarManager>();
    }

    void Update()
    {
        float h = energyBar.currentHeight;

        //Check height of energy bar and activate player weapons accordingly
        foreach (weapon weapon in weapons)
        {
            weapon.SetActive(h);
        }
        
        //Firing Logic
        if (Time.time > nextFireTime)
        {
            //Pressing x shoots activated weapons
            if (Input.GetKey(KeyCode.X))
            {
                foreach (weapon weapon in weapons)
                {
                    weapon.Shoot();
                }
                nextFireTime = Time.time + cooldownDuration;
            }
        }

        //Movement controls
        moveUp = Input.GetKey(KeyCode.UpArrow);
        moveDown = Input.GetKey(KeyCode.DownArrow);
        moveLeft = Input.GetKey(KeyCode.LeftArrow);
        moveRight = Input.GetKey(KeyCode.RightArrow);
    }

    private void FixedUpdate()
    {
        //Change movement speed based on energy bar height
        float h = energyBar.currentHeight;
        
        moveSpeed = 5 + h/2;

        Vector2 pos = transform.position;

        float moveAmount = moveSpeed * Time.fixedDeltaTime;
        Vector2 move = Vector2.zero;

        //Movement
        if(moveUp)
        {
            move.y += moveAmount;
        }
        if(moveDown)
        {
            move.y -= moveAmount;
        }
        if(moveLeft)
        {
            move.x -= moveAmount;
        }
        if(moveRight)
        {
            move.x += moveAmount;
        }

        pos += move;

        //Movement Boundaries to stay within playspace
        if(pos.y >= 4.3f)
        {
            pos.y = 4.3f;
        }

        if(pos.y <= -4.55f)
        {
            pos.y = -4.55f;
        }

        if(pos.x >= 3.98f)
        {
            pos.x = 3.98f;
        }

        if(pos.x <= -4.53f)
        {
            pos.x = -4.53f;
        }

        transform.position = pos;
    }
}
