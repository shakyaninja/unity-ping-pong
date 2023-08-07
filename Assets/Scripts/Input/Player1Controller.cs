using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller : InputController
{
    private Vector2 direction;
    protected override void handleMovement()
    {
        racketRB.velocity = new Vector2(0, Input.GetAxis("Player1") * controlSpeed) * GameManager.Instance.pControlDir[0];
    }

    /*protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        float collisionPoint = (collision.gameObject.transform.position.y - racketCollider.bounds.size.y) / racketCollider.bounds.size.y;
        //direction = collisionPoint > 0 ? new Vector2() : new Vector2(); 
        Debug.Log(string.Format("collision point : {0}", collisionPoint));
    }*/
}
