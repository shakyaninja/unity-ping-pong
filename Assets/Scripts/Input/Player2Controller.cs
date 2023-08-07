using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : InputController
{
    protected override void handleMovement()
    {
        racketRB.velocity = new Vector2(0, Input.GetAxis("Player2") * controlSpeed) * GameManager.Instance.pControlDir[1];
    }
}
