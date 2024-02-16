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
    [SerializeField] static float timeLeft = 10f;
    public static bool GameStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameStarted)
        {
            header.text = "Score: " + playerScore;
            timer.text = "Time: " + Mathf.RoundToInt(timeLeft);
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0)
            {
                GameStarted = false;
                timeLeft += 10f;
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

    public void EndGame()
    {
        Destroy(GameObject.Find("Mole(Clone)"));
        MoleSpawner.moleOnScreen = false;
        SceneManager.LoadScene("EndScreen");
    }
}
