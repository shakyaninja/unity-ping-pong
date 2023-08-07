using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3Controller : InputController
{
    private Vector2 direction;
    protected override void handleMovement()
    {
        racketRB.velocity = new Vector2(Input.GetAxis("Player3") * controlSpeed, 0) * GameManager.Instance.pControlDir[2];
    }

    /*protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        float collisionPoint = (collision.gameObject.transform.position.y - racketCollider.bounds.size.y) / racketCollider.bounds.size.y;
        //direction = collisionPoint > 0 ? new Vector2() : new Vector2(); 
        Debug.Log(string.Format("collision point : {0}", collisionPoint));
    }*/
}
