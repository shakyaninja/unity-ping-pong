using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{

    IEnumerator CheckTimer()
    {
        for (; ; ) //infinite loop
        {
            // execute block of code here
            yield return new WaitForSeconds(1);
            StatManager.Instance.incrementTimer();   
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if(GameManager.Instance.getActiveScene().name == "GameScene")
        {
            StartCoroutine("CheckTimer");
            StartCoroutine("SpawnPowerUp");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(StatManager.Instance.timer == 60)
        {
            //Debug.Log("triggered game over");
            GameManager.Instance.loadGameOver();
        }
    }

    IEnumerator SpawnPowerUp()
    {
        yield return new WaitForSeconds(10);
        GameManager.Instance.canSpawnPowerUp = true;
    }
}
