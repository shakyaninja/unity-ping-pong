using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    private Scene activeScene;
    public float[] pControlDir = new float[4] { 1, 1, 1, 1 };
    public int isLastHitBy = 0;
    public delegate void CoolDownDelegate(int player);

    private void Awake()
    {
        Instance = this; 
    }

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.Play("Theme");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Scene getActiveScene()
    {
        activeScene =SceneManager.GetActiveScene();
        return activeScene;
    }

    public void loadMainMenu()
    {
        loadScene(0);
    }

    public void loadGameScene()
    {
        loadScene(1);
    }

    public void loadGameOver()
    {
        loadScene(2);
    }

    public void loadScene(int index)
    {
        Debug.Log(index);
        SceneManager.LoadScene(index);
    }

    public void spawnPowerUp(string name)
    {
        Vector2 position = new Vector2(0, 0);
        
    }

    public void setIsLastHitBy(string player)
    {
        switch (player)
        {
            case "player1":
                isLastHitBy = 1;
                break;

            case "player2":
                isLastHitBy = 2;
                break;

            case "player3":
                isLastHitBy = 3;
                break;

            case "player4":
                isLastHitBy = 4;
                break;

            default:
                isLastHitBy = 0;
                break;
        }
    }

    public void activatePowerUpFor(string name)
    {
       switch(isLastHitBy)
        {
            case 1:
                //activate for p1
                break;

            case 2:
                //activate for p2
                break;

            case 3:
                //activate for p3
                break;

            case 4:
                //activate for p4
                break;

            default:
                break;

        }
    }

    public void activatePowerUp(string name)
    {
        switch (name)
        {
            case "power-up-reverse-control":
                reverseControl(isLastHitBy);
                break;

            case "power-up-slow-time":
                slowTime(isLastHitBy);
                break;

            default:
                break;

        }
    }

    public void reverseControl(int player)
    {
        Debug.Log(string.Format("reverse control of {0}", player));
        //do it for player 
        pControlDir[player] = -1;
        StartCoroutine(cooldownPowerUp(player, 6));
    }

    public void slowTime(int player)
    {
        Debug.Log(string.Format("slow time of {0}", player));
        //do it for player 
        pControlDir[player] = 0.2f;
    }

    public void slowTimeReset(int player)
    {
        pControlDir[player] = 1;
    }

    public void reverseControlReset(int player)
    {
        pControlDir[player] = 1;
    }

    IEnumerator cooldownPowerUp(int player, int time )
    {
        yield return new WaitForSeconds(time);
        reverseControlReset(player);
    }
}
