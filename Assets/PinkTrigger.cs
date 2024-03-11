using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinkTrigger : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }

    public int pink_score { get; private set; }
    public int win_score { get; private set; }
    public void Startup()
    {
        Debug.Log("Pink manager starting...");
        pink_score = 0;
        win_score = 4;
        status = ManagerStatus.Started;
    }
    // allows controllers/other scripts to access this script
    //public static PinkTrigger instance;
    public P1Control player;
    //public Text scoreText;
    //public Text winText;

    bool canScore;

    /* private void Awake()
     {
         instance = this;
     }*/
    void Start()
    {
        //scoreText.text = pink_score.ToString() + " Pink Points";
        Debug.Log(pink_score.ToString() + " Pink Points");
        canScore = true;
        //winText.text = ""; // Assign an empty string to the text property of winText
    }



    public void AddPoint()
    {
        if (canScore == true)
        {
            pink_score += 1;
            //scoreText.text = pink_score.ToString() + " Pink Points";
            Debug.Log(pink_score.ToString() + " Pink Points");
            canScore = false;
            StartCoroutine("SetCanScore");
            if (pink_score == 4)
            {
                pink_score = win_score;
            }
        }

    }

    public void MinusPoint()
    {
        pink_score -= 1;
        //scoreText.text = pink_score.ToString() + " Pink Points";
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
