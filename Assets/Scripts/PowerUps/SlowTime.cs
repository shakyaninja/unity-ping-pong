using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTime : PowerUp
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ball"))
        {
            //activate power up by checking which player has last hit the ball
            GameManager.Instance.activatePowerUp(gameObject.tag);
            gameObject.SetActive(false);
        }
    }
}
