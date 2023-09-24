using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startGame : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKey(KeyCode.X))
        {
            SceneManager.LoadScene("gamePlay");
        }
    }
}
