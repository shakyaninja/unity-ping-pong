using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    private Scene activeScene;


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

    public void spawnPowerUp()
    {

    }
}
