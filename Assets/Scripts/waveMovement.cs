using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveMovement : MonoBehaviour
{
    float placementX;

    public bool inversion = false;
    public bool active = false;
    public float amp = 1;
    public float freq = 1;

    void Start()
    {
        placementX = transform.position.x;
    }

    void Update()
    {
        //Sine wave movement behaviour allowing customisation of frequency, amplitude and whether the wave is inverted or not
        if(active)
        {
            Vector2 pos = transform.position;

            float sin = Mathf.Sin(pos.y * freq) * amp;
            if (inversion)
            {
                sin = sin * -1;
            }
            pos.x = placementX + sin;
            transform.position = pos;
        }
        
    }
}
