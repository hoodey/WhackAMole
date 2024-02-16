using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    //Variables to init on program start
    [SerializeField] TMP_Text highScoreD;
    [SerializeField] TMP_Text currentScoreD;
    [SerializeField] TMP_Text greeting;
    public static int highScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        //Set current score text on screen
        currentScoreD.text = "Round Score: " + (Score.getScore()).ToString();
        //If highscore was lower than the round score, update and show
        if (Score.getScore() > highScore)
        {
            highScore = Score.getScore();
            highScoreD.text = "High Score: " + (Score.getScore()).ToString();
            greeting.text = "Nice job! You beat the high score!";
        }
        //If the highscore was tied with the round score, update and show
        else if (Score.getScore() == highScore)
        {
            highScore = Score.getScore();
            highScoreD.text = "High Score: " + (Score.getScore()).ToString();
            greeting.text = "Whacky! You tied the high score!";
        }
        //If the highscore was higher than the round score, show
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

    //Create a function to transition scenes on mouse click and reset the round score
    public void restart()
    {
        Score.setScore(0);
        SceneManager.LoadScene("WhackAScene");
    }
}
