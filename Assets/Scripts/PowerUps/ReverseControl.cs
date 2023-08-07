using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseControl : PowerUp
{
    private bool isTriggred = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isTriggred && collision.gameObject.CompareTag("ball"))
        {
            //activate power up by checking which player has last hit the ball
            GameManager.Instance.activatePowerUp(gameObject.tag);
            //disable the powerup
            //gameObject.SetActive(false);

        }
    }


}
