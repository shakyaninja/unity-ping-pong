using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    public GameObject[] powerUps;
    public GameObject[] shields;
    public GameObject ball;
    public ParticleSystem prtclSystem;
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
        if (canSpawnPowerUp)
        {
            //Debug.Log(powerUps);
            //Debug.Log(powerUps[Random.Range(0, 3)]);
            //spawn power ups randomly
            spawnPowerUp(powerUps[Random.Range(0, 3)]);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            /*Time.timeScale = (Time.timeScale == 1.0f) ? 0f:1.0f;
            //trigger pause*/
            Application.Quit();
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

    public void loadInstructions()
    {
        loadScene(3);
    }

    public void loadScene(int index)
    {
        Debug.Log(index);
        SceneManager.LoadScene(index);
    }

    public void spawnPowerUp(GameObject powerUp)
    {
        canSpawnPowerUp = false;
        Debug.Log("powerup name : " + name);
        Vector2 position = new Vector2(Random.Range(0,10), Random.Range(-3, 2));
        powerUp.transform.position = position;
        powerUp.SetActive(true);
    }

    public void setIsLastHitBy(string player)
    {
        switch (player)
        {
            case "Player1":
                isLastHitBy = 1;
                break;

            case "Player2":
                isLastHitBy = 2;
                break;

            case "Player3":
                isLastHitBy = 3;
                break;

            case "Player4":
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
            case "powerUpReverseControl":
                reverseControl(isLastHitBy);
                break;

            case "powerUpSlowTime":
                slowTime(isLastHitBy);
                break;

            case "powerUpShield":
                shield(isLastHitBy);
                break;

            case "powerUpIllusion":
                illusion();
                break;

            case "powerUpGhost":
                ghost();
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
        StartCoroutine(cooldownPowerUp( 6));
    }

    public void slowTime(int player)
    {
        Debug.Log(string.Format("slow time of {0}", player));
        //do it for player 
        pControlDir[player] = 0.2f;
        StartCoroutine(cooldownPowerUp(6));
    }

    public void shield(int player)
    {
        Debug.Log(string.Format("shield of {0}", player));
        shields[player].SetActive(true);
        StartCoroutine(cooldownPowerUp(6));
    }

    public void illusion()
    {
        Debug.Log(string.Format("illusion "));
        //illusion of multiple balls
        StartCoroutine("SpawnParticle");
    }

    private IEnumerator SpawnParticle()
    {
        //Debug.Log("spawn particle called");
        prtclSystem.Play();
        yield return new WaitForSeconds(3f);
        prtclSystem.Stop();
    }

    public void ghost()
    {
        Debug.Log(string.Format("ghost "));
        ball.gameObject.SetActive(false);
        StartCoroutine(cooldownPowerUp( 1));
    }

    public void powerUpReset()
    {
        //reset coontrols
        pControlDir = new float[] { 1, 1, 1, 1 };
        //reset shields
        foreach (var shield in shields)
        {
            shield.SetActive(false);
        }
        //reset ghost
        ball.gameObject.SetActive(true);
    }

    IEnumerator cooldownPowerUp(int time )
    {
        yield return new WaitForSeconds(time);
        //reset all powerups
        powerUpReset();
        canSpawnPowerUp = true;
    }
}
