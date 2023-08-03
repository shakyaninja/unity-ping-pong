using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    private Scene activeScene;
    private int p1ControlDir = 1;
    private int p2ControlDir = 1;
    private int p3ControlDir = 1;
    private int p4ControlDir = 1;
    public int isLastHitBy = 0;


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

    public void activatePowerUp(int player,string name)
    {
        switch (name)
        {
            case "reverse-control":
                break;

            default:
                break;

        }
    }

    public void reverseControl()
    {
        p1ControlDir = -1;
    }
}
