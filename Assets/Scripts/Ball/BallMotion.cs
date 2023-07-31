using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMotion : MonoBehaviour
{
    private float incremenntalFactor = 2.0f;
    private float startSpeed = 200.0f;
    public Rigidbody2D ballRB { get; set; } //define rigidbody for ball

    // Start is called before the first frame update
    void Start()
    {
        /*assign own rigidbody2D*/
        ballRB = GetComponent<Rigidbody2D>();
        Move(new Vector2(15.0f, 0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Move(Vector2 direction)
    {
        direction = direction.normalized;
        ballRB.velocity = direction * startSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*check collision with racket*/
        if (collision.gameObject.CompareTag("racket"))
        {
            /*increase speed*/
            ballRB.velocity *= incremenntalFactor;
        }
    }
}
