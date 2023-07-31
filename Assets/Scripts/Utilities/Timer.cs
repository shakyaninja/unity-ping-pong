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
        Debug.Log(string.Format("current scene : {0}", GameManager.Instance.getActiveScene().name));
        if(GameManager.Instance.getActiveScene().name == "GameScene")
        {
            StartCoroutine("CheckTimer");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(StatManager.Instance.timer == 60)
        {
            GameManager.Instance.loadGameOver();
        }
    }
}
