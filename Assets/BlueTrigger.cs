using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlueTrigger : MonoBehaviour
{
    // allows controllers/other scripts to access this script
    public P2Control player;
    public Text scoreText;

    public Text winText;
    int blue_score = 0;
    bool canScore;

    /* private void Awake()
     {
         instance = this;
     }*/
    void Start()
    {
        scoreText.text = blue_score.ToString() + " Blue Points";
        Debug.Log(blue_score.ToString() + " Blue Points");
        canScore = true;
        winText.text = ""; // Assign an empty string to the text property of winText
    }



    public void AddPoint()
    {
        if (player.isJumping && canScore == true)
        {
            blue_score += 1;
            scoreText.text = blue_score.ToString() + " Blue Points";
            Debug.Log(blue_score.ToString() + " Blue Points");
            canScore = false;
            StartCoroutine("SetCanScore");
            if (blue_score == 4)
            {
                winText.text = "Blue Wins!";
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

/*public class BlueTrigger : MonoBehaviour
{
    private int Blue_Points;

    void Start()
    {
        Blue_Points = 0;
    }
    private void OnTriggerEnter(Collider other)
    {
        Blue_Points = Blue_Points + 1;
        Debug.Log("Blue's Points: " + Blue_Points);
    }
}*/

