using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    private Scene activeScene;
    public float[] pControlDir = new float[4] { 1, 1, 1, 1 };
    public int isLastHitBy = 0;
    public bool canSpawnPowerUp = false;
    public string[] powerUps = new string[4] { "power-up-reverse-control", "power-up-slow-time", "power-up-shield", "power-up-illusion" };

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
    void FixedUpdate()
    {   
        if(canSpawnPowerUp)
        {
            //spawn power ups randomly
            spawnPowerUp(powerUps[Random.Range(0,3)]);
        }
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
        Debug.Log("powerup name : " + name);
        Vector2 position = new Vector2(Random.Range(0,14), Random.Range(-4, 2));
        //find object from heirarchy
        GameObject powerUpObj = GameObject.FindGameObjectWithTag(name);
        powerUpObj.transform.position = position;
        powerUpObj.SetActive(true);
        //enable it
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

            case "power-up-shield":
                slowTime(isLastHitBy);
                break;

            case "power-up-illusion":
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

    public void shield(int player)
    {
        Debug.Log(string.Format("shield of {0}", player));
        
        
    }

    public void illusion()
    {
        Debug.Log(string.Format("illusion "));

    }

    public void powerUpReset()
    {
        pControlDir = new float[] { 1, 1, 1, 1 };
    }

    IEnumerator cooldownPowerUp(int player, int time )
    {
        yield return new WaitForSeconds(time);
        //reset all powerups
        powerUpReset();
        canSpawnPowerUp = true;
    }
}
