using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    //Variables
    [SerializeField] TMP_Text highScoreD;
    [SerializeField] TMP_Text currentScoreD;
    [SerializeField] TMP_Text greeting;
    public static int highScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentScoreD.text = "Round Score: " + (Score.getScore()).ToString();
        if (Score.getScore() > highScore)
        {
            highScore = Score.getScore();
            highScoreD.text = "High Score: " + (Score.getScore()).ToString();
            greeting.text = "Nice job! You beat the high score!";
        }
        else if (Score.getScore() == highScore)
        {
            highScore = Score.getScore();
            highScoreD.text = "High Score: " + (Score.getScore()).ToString();
            greeting.text = "Whacky! You tied the high score!";
        }
        else
        {
            highScoreD.text = "High Score: " + highScore.ToString();
            greeting.text = "Great! Try again to beat the high score!";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Create a function to transition scenes on mouse click
    public void restart()
    {
        Score.setScore(0);
        SceneManager.LoadScene("WhackAScene");
    }
}
