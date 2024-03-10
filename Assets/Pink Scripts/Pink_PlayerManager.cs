using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pink_PlayerManager : MonoBehaviour, Pink_IGameManager
{
    public Pink_ManagerStatus status { get; private set; }

    public int pink_score { get; private set; }
    //public int win_score { get; private set; }
    public P1Control player;
    public Text scoreText;
    // public Text winText;

    bool canScore;

    public void Startup()
    {
        Debug.Log("Pink player manager starting...");
        pink_score = 0;
        // win_score = 4;
        canScore = true;
        status = Pink_ManagerStatus.Started;
        scoreText.text = pink_score.ToString() + " Pink Points";
        //winText.text = "";
    }

    public void AddPoint()
    {
        if (player.isJumping && canScore == true)
        {
            pink_score += 1;
            scoreText.text = pink_score.ToString() + " Pink Points";
            Debug.Log(pink_score.ToString() + " Pink Points");
            canScore = false;
            StartCoroutine("SetCanScore");
            if (pink_score == 4)
            {
                scoreText.text = "Pink Wins!";
                //winText.text = "Pink Wins!";
            }
        }

    }

    public void MinusPoint()
    {
        pink_score -= 1;
        scoreText.text = pink_score.ToString() + " Pink Points";
        Debug.Log(pink_score.ToString() + " Pink Points");
        canScore = false;
        StartCoroutine("SetCanScore");

    }

    IEnumerator SetCanScore()
    {
        yield return new WaitForSeconds(1);
        canScore = true;
    }


}

