using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class victoryMark : MonoBehaviour
{
    public victory victory;
    private Transform playerTransform;
    private player playerScriptComponent;
    private scoreManager scoreManager;

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.transform;
        playerScriptComponent = player.GetComponent<player>();

        scoreManager = FindObjectOfType<scoreManager>();
    }

    public void Update()
    {
        Vector2 pos = transform.position;

        //Stop player from using ship when the game is won and start up the victory screen
        if (pos.y < -5 && playerTransform != null)
        {
            Destroy(playerScriptComponent);
            victory.Setup(scoreManager.score);
        }
    }
}
