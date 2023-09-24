using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class scoreManager : MonoBehaviour
{
    public static int score = 0;
    private TextMeshProUGUI scoreText;


    private void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        score = 0;
        UpdateScoreText();

    }

    //Provide function for other scripts to update the score
    public void IncreaseScore(int amount)
    {
        score += amount;

        if(score <= 0)
        {
            score = 0;
        }
        
        UpdateScoreText();
    
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

}