using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class Score : MonoBehaviour
{
    //ScoreUI Variables
    [SerializeField] TMP_Text header;
    [SerializeField] TMP_Text timer;
    [SerializeField] static int playerScore = 0;
    [SerializeField] static float timeLeft = 30f;
    public static bool GameStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Conditional if the game has started (via the start button), show what the players score is, show the time remaining, decrease the time every second, and when time runs out, reset variables and end game
        if (GameStarted)
        {
            header.text = "Score: " + playerScore;
            timer.text = "Time: " + Mathf.RoundToInt(timeLeft);
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0)
            {
                GameStarted = false;
                timeLeft += 30f;
                EndGame();
            }
        }
    }

    //Create a function to get the score
    public static int getScore()
    {
        return playerScore;
    }

    //Create an increaser for playerscore
    public static void increaseScore(int score)
    {
        playerScore += score;
    }

    //Create a setter for playerscore
    public static void setScore(int score)
    {
        playerScore = score;
    }

    //Create a function to start the game
    public void StartGame()
    {
        if (!GameStarted)
            GameStarted = true;
    }

    //Create a function to end the game
    public void EndGame()
    {
        Destroy(GameObject.Find("Mole(Clone)"));
        MoleSpawner.moleOnScreen = false;
        SceneManager.LoadScene("EndScreen");
    }
}
