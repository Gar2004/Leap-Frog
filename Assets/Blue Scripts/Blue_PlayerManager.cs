using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Blue_PlayerManager : MonoBehaviour, Blue_IGameManager
{
    // Wanted to have the action of being lept over the loss of a point, but it was not working.
    // For some reason the minus function would only work if I did not use the commented out couroutine.
    // This however would cause the player to lose multiple points if lept over once. 
    public Blue_ManagerStatus status { get; private set; }

    public int blue_score { get; private set; }
    //public int win_score { get; private set; }
    public P2Control Blue_player;

    //public Pink_PlayerManager Pink;

    //[SerializeField] TimerScript TimeLeft;
    public Text scoreText;
    // public Text winText;

    //private bool canScore;

    public void Startup()
    {
        Debug.Log("Blue player manager starting...");
        blue_score = 0;
        // win_score = 4;
        status = Blue_ManagerStatus.Started;
        scoreText.text = blue_score.ToString() + " Blue Points";
        // canScore = true;

        //winText.text = "";
    }

    public void AddPoint()
    {
        blue_score += 1;
        scoreText.text = blue_score.ToString() + " Blue Points";
        Debug.Log(blue_score.ToString() + " Blue Points");
        // StartCoroutine("SetCanScore");
        /* if (TimeLeft.TimeLeft <= 0 && blue_score > Pink.pink_score)
         {
             scoreText.text = "Blue Wins!";
             //winText.text = "Pink Wins!";
         }
         if (TimeLeft.TimeLeft <= 0 && blue_score == Pink.pink_score)
         {
             scoreText.text = "Tie!";
             //winText.text = "Pink Wins!";
         }*/
        // canScore = false;

    }

    public void MinusPoint()
    {
        //if (canScore == true)
        //{
        Debug.Log("Blue Minus Point");
        blue_score -= 1;
        scoreText.text = blue_score.ToString() + " Blue Points";
        Debug.Log(blue_score.ToString() + " Blue Points");
        //canScore = false;
        // StartCoroutine(SetCanScore());
        // }
        /*if (TimeLeft.TimeLeft <= 0 && blue_score > Pink.pink_score)
        {
            scoreText.text = "Blue Wins!";
            //winText.text = "Pink Wins!";
        }
        if (TimeLeft.TimeLeft <= 0 && blue_score == Pink.pink_score)
        {
            scoreText.text = "Tie!";
            //winText.text = "Pink Wins!";
        }*/

    }

    /* IEnumerator SetCanScore()
     {
         yield return new WaitForSeconds(0);
         canScore = true;
     }*/


}


