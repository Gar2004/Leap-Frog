using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinkTrigger : MonoBehaviour
{
    // allows controllers/other scripts to access this script
    //public static PinkTrigger instance;
    public P1Control player;
    public Text scoreText;
    int pink_score = 0;

    bool canScore;

    /* private void Awake()
     {
         instance = this;
     }*/
    void Start()
    {
        scoreText.text = pink_score.ToString() + " Pink Points";
        Debug.Log(pink_score.ToString() + " Pink Points");
        canScore = true;
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

/*public class PinkTrigger : MonoBehaviour
{
    private int Pink_Points;

    void Start()
    {
        Pink_Points = 0;
    }
    private void OnTriggerEnter(Collider other)
    {
        Pink_Points = Pink_Points + 1;
        Debug.Log("Pink's Points: " + Pink_Points);
    }
}*/
