using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blue_PlayerManager : MonoBehaviour, Blue_IGameManager
{
    public Blue_ManagerStatus status { get; private set; }

    public int blue_score { get; private set; }
    //public int win_score { get; private set; }
    public P2Control Blue_player;
    public Text scoreText;
    // public Text winText;

    bool canScore;

    public void Startup()
    {
        Debug.Log("Blue player manager starting...");
        blue_score = 0;
        // win_score = 4;
        canScore = true;
        status = Blue_ManagerStatus.Started;
        scoreText.text = blue_score.ToString() + " Blue Points";
        //winText.text = "";
    }

    public void AddPoint()
    {
        if (Blue_player.isJumping && canScore == true)
        {
            blue_score += 1;
            scoreText.text = blue_score.ToString() + " Blue Points";
            Debug.Log(blue_score.ToString() + " Blue Points");
            canScore = false;
            StartCoroutine("SetCanScore");
            if (blue_score == 4)
            {
                scoreText.text = "Blue Wins!";
                //winText.text = "Pink Wins!";
            }
        }

    }

    public void MinusPoint()
    {
        blue_score -= 1;
        scoreText.text = blue_score.ToString() + " Blue Points";
        Debug.Log(blue_score.ToString() + " Blue Points");
        canScore = false;
        StartCoroutine("SetCanScore");

    }

    IEnumerator SetCanScore()
    {
        yield return new WaitForSeconds(1);
        canScore = true;
    }


}


