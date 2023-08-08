using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager: MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreP1;
    [SerializeField] private TextMeshProUGUI scoreP2;
    [SerializeField] private TextMeshProUGUI scoreP3;
    [SerializeField] private TextMeshProUGUI scoreP4;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI winnerText;
    [SerializeField] private TextMeshProUGUI loserText;
    [SerializeField] private Button mainMenu, start, retry, highscore;
    [SerializeField] private PowerUp[] powerups;
    public static UIManager Instance;

    public void Awake()
    {
        Instance = this; 
    }

    public void Start()
    {
        if (SceneManager.GetActiveScene().name == "MainMenuScene")
        {
            start.onClick.AddListener(GameManager.Instance.loadGameScene);
            highscore.onClick.AddListener(GameManager.Instance.loadGameScene);
        }
        //check scene
        if(SceneManager.GetActiveScene().name == "GameOverScene")
        {
            mainMenu.onClick.AddListener(GameManager.Instance.loadMainMenu);
            retry.onClick.AddListener(GameManager.Instance.loadGameScene);
        }
    }

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
        timerText.text = (timerValue).ToString();
    }

    public void announceWinner()
    {
        StatManager.Instance.chooseWinner();
        winnerText.text = string.Format("{0} won.", StatManager.Instance.winner);
    }

    public void announceLoser()
    {
        StatManager.Instance.chooseLoser();
        loserText.text = string.Format("{0} lost.", StatManager.Instance.loser);
    }

}
