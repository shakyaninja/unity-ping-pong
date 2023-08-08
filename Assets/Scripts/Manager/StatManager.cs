using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class StatManager : MonoBehaviour
{

    public static StatManager Instance;

    public int hits = 0;
    public int scoreP1 = 0;
    public int scoreP2 = 0;
    public int scoreP3 = 0;
    public int scoreP4 = 0;
    public int timer = 0;
    public string winner = "";
    public string loser = "";
    public void Awake()
    {
        Instance = this;
    }

    public void incrementScoreP1()
    {
        scoreP1 ++;
        //do update UIManager
        UIManager.Instance.scorePlayer1(scoreP1);
    }

    public void incrementScoreP2()
    {
        scoreP2 ++;
        //do update UIManager
        UIManager.Instance.scorePlayer2(scoreP2);
    }

    public void incrementScoreP3()
    {
        scoreP3++;
        //do update UIManager
        UIManager.Instance.scorePlayer3(scoreP3);
    }

    public void incrementScoreP4()
    {
        scoreP4++;
        //do update UIManager
        UIManager.Instance.scorePlayer4(scoreP4);
    }

    public void incrementTimer()
    {
        timer++;
        //do update UIManager
        UIManager.Instance.incrementTimerText(timer);
    }

    public void chooseWinner()
    {
        int[] scoreList = { scoreP1, scoreP2, scoreP3, scoreP4 };
        int maxValue = scoreList.Max();
        //check for highscore
        int maxIndex = scoreList.ToList().IndexOf(maxValue);
        switch (maxIndex)
        {
            case 0:
                winner = "Player 1";
                break;

            case 1:
                winner = "Player 2";
                break;

            case 2:
                winner = "Player 3";
                break;

            case 3:
                winner = "Player 4";
                break;

            default:
                break;
        }
    }

    public void chooseLoser()
    {
        int[] scoreList = { scoreP1, scoreP2, scoreP3, scoreP4 };
        int minValue = scoreList.Min();
        //check for lowestscore
        int minIndex = scoreList.ToList().IndexOf(minValue);
        switch (minIndex)
        {
            case 0:
                loser = "Player 1";
                break;

            case 1:
                loser = "Player 2";
                break;

            case 2:
                loser = "Player 3";
                break;

            case 3:
                loser = "Player 4";
                break;

            default:
                break;
        }
    }

}
