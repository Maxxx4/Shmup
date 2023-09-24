using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using TMPro;
public class victory : MonoBehaviour
{
    public TextMeshProUGUI finalScore;
    public Button defaultButton;

    public void Setup(int score)
    {
            gameObject.SetActive(true);
            finalScore.text = "Score: " + score.ToString();
            defaultButton.Select();
    }

    public void RestartV()
    {
        SceneManager.LoadScene("gamePlay");
    }

    public void MenuV()
    {
        SceneManager.LoadScene("menu");
    }
}
