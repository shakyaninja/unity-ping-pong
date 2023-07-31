using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    protected float controlSpeed = 5.0f;
    protected Rigidbody2D racketRB;
    protected Collider2D racketCollider;


    protected int Point { get; set; }
    private Rigidbody2D ballRB;

    // Start is called before the first frame update
    protected void Start()
    {
        racketRB = GetComponent<Rigidbody2D>();
        racketCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        handleMovement();
    }

    protected virtual void handleMovement()
    {
      
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        /*get collision object and get racket info then find direction to reflect back ball*/
        if (collision.gameObject.CompareTag("ball"))
        {
            ballRB = collision.gameObject.GetComponent<Rigidbody2D>();
            /*increase speed of ball*/

        }
    }
}
