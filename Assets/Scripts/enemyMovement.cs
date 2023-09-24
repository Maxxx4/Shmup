using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    public float moveSpeed = 1;
    private float outsideSpeed = 5;

    void FixedUpdate()
    {
        Vector2 pos = transform.position;

        //Move enemies at their unique speed, unless they are outside of the players screen in which case they move at the same speed
        if(transform.position.y <= 5f)
        {
            pos.y -= moveSpeed * Time.fixedDeltaTime;
            transform.position = pos;
        }
        else
        {
            pos.y -= outsideSpeed * Time.fixedDeltaTime;
            transform.position = pos;
        }
        
        if (pos.y < -5.5)
        {
            Destroy(gameObject);
        }
        
    }
}
