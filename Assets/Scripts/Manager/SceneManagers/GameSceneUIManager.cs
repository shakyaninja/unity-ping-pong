using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameSceneUIManager : UIManager
{


    public void scorePlayer1(int score)
    {
        scoreP1.text = score.ToString();
    }

    public void scorePlayer2(int score)
    {
        scoreP2.text = score.ToString();
    }

    public void scorePlayer3(int score)
    {
        scoreP3.text = score.ToString();
    }

    public void scorePlayer4(int score)
    {
        scoreP4.text = score.ToString();
    }

    public void incrementTimerText(int timerValue)
    {
        timerText.text = timerValue.ToString();
    }

}
