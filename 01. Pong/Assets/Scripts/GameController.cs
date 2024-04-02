using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject[] scoreText;
    public int[] score;
    public GameObject ball;

    private void OnEnable()
    {
        ball.GetComponent<BallController>().addScore += AddScore;
    }

    private void OnDisable()
    {
        ball.GetComponent<BallController>().addScore -= AddScore;
    }

    // Start is called before the first frame update
    void Start()
    {
        int i = 0;
        foreach(GameObject _ in scoreText)
        {
            scoreText[i].GetComponent<TMP_Text>().text = "0";
            score[i] = 0;
            i++;
        }
    }

    private void AddScore(int side)
    {
        score[side]++;
        scoreText[side].GetComponent<TMP_Text>().text = score[side].ToString();
    }
}
