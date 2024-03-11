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

    //public Blue_PlayerManager Blue;

    // [SerializeField] TimerScript TimeLeft;
    public Text scoreText;
    // public Text winText;

    //bool canScore;

    public void Startup()
    {
        Debug.Log("Pink player manager starting...");
        pink_score = 0;
        // win_score = 4;
        //canScore = true;
        status = Pink_ManagerStatus.Started;
        scoreText.text = pink_score.ToString() + " Pink Points";
        //winText.text = "";
    }

    public void AddPoint()
    {

        pink_score += 1;
        scoreText.text = pink_score.ToString() + " Pink Points";
        Debug.Log(pink_score.ToString() + " Pink Points");
        //canScore = false;
        // StartCoroutine("SetCanScore");
        /*if (TimeLeft.TimeLeft <= 0 && pink_score > Blue.blue_score)
        {
            scoreText.text = "Pink Wins!";
            //winText.text = "Pink Wins!";
        }
        if (TimeLeft.TimeLeft <= 0 && pink_score == Blue.blue_score)
        {
            scoreText.text = "Tie!";
        }*/


    }

    public void MinusPoint()
    {
        pink_score -= 1;
        scoreText.text = pink_score.ToString() + " Pink Points";
        Debug.Log(pink_score.ToString() + " Pink Points");
        //canScore = false;
        // StartCoroutine("SetCanScore");
        /* if (TimeLeft.TimeLeft <= 0 && pink_score > Blue.blue_score)
         {
             scoreText.text = "Pink Wins!";
             //winText.text = "Pink Wins!";
         }
         if (TimeLeft.TimeLeft <= 0 && pink_score == Blue.blue_score)
         {
             scoreText.text = "Tie!";
         }*/


    }

    /* IEnumerator SetCanScore()
     {
         yield return new WaitForSeconds(1);
         canScore = true;
     }*/


}

