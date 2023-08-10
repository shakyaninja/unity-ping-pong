using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private float startSpeed;
    [SerializeField] private float incrementFactor;
    [SerializeField] private float maxSpeed;
    [SerializeField] private int hits = 0;

    public ParticleSystem prtclSystem;
    private Vector2 previousDirection = Vector2.zero;
    private int sameDirectionHit = 0;


    Rigidbody2D ballRB;
    Rigidbody2D racketRB;
    TrailRenderer trailRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        ballRB = GetComponent<Rigidbody2D>(); // select RB from current component
        trailRenderer = GetComponent<TrailRenderer>();
        StartCoroutine(Timer(2));
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void Move ( Vector2 direction) 
    {
        direction = direction.normalized;
        ballRB.velocity = direction * startSpeed * Time.fixedDeltaTime;
    }

    private IEnumerator Timer (float waitingSeconds)
    {
        yield return new WaitForSeconds(waitingSeconds);
        Move(new Vector2(-10, 0));
    }

    private IEnumerator RespawnBall(float waitingSeconds)
    {
        //reset hits
        hits = 0;
        //play point music
        AudioManager.Instance.Play("BallHit");
        //hide ball
        trailRenderer.enabled = false;
        ballRB.velocity = Vector2.zero;
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        ballRB.transform.position = new Vector2(0,0);
        yield return new WaitForSeconds(waitingSeconds);
        //show ball
        this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        trailRenderer.enabled = true;
        Move(new Vector2(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f)));
    }

    private IEnumerator SpawnParticle()
    {
        //Debug.Log("spawn particle called");
        prtclSystem.Play();
        yield return new WaitForSeconds(0.7f);
        prtclSystem.Stop();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision);
        //Vector2 directionHit = collision.GetContact(0).normal;
        //Vector2 clampDirection = Vector2.ClampMagnitude(directionHit, 0.8f);

        bool IsVectorInRange(Vector2 vector, Vector2 min, Vector2 max)
        {
            return vector.x >= min.x && vector.x <= max.x &&
                   vector.y >= min.y && vector.y <= max.y;
        }


        if (collision.gameObject.CompareTag("racket") && ((incrementFactor * hits * Time.deltaTime) + ballRB.velocity.magnitude) < maxSpeed)
        {
            //play hit sound
            AudioManager.Instance.Play("BallHitWall");

            hits ++;


            // Calculate the new direction based on the collision point
            Vector2 collisionPoint = collision.GetContact(0).point;
            Vector2 racketCenter = collision.gameObject.transform.position;
            Vector2 direction = collisionPoint - racketCenter;
            direction.Normalize();
            //using contact normal
            Vector2 contactNormal = collision.GetContact(0).normal;

            if (IsVectorInRange(collisionPoint, previousDirection - new Vector2(0.2f,0.2f), previousDirection + new Vector2(0.2f, 0.2f)))
            {
               // Debug.Log("same direction hit ");
                sameDirectionHit++;
            }
        
            if (sameDirectionHit > 3)
            {
                //Debug.Log("trigger random direction");
                //give random direction
                ballRB.velocity = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)) * ballRB.velocity.magnitude;
                sameDirectionHit = 0;
            }

            //handle particle spawn
            prtclSystem.transform.position = collisionPoint;
            StartCoroutine("SpawnParticle");
            //Debug.Log(clampDirection);

            // Update the ball's velocity with the new direction and increased speed
            ballRB.velocity = (ballRB.velocity.magnitude + (incrementFactor * hits * Time.deltaTime)) * direction;
        }
        else if (collision.gameObject.CompareTag("rightBorder"))
        {
            //increase score of players other than 2
            scoreP1();
            scoreP3();
            scoreP4();
            StartCoroutine(RespawnBall(2));
        }
        else if (collision.gameObject.CompareTag("leftBorder"))
        {
            //increase score of  players other than 1
            scoreP2();
            scoreP3();
            scoreP4();
            StartCoroutine(RespawnBall(2));
        }
        else if (collision.gameObject.CompareTag("bottomBorder"))
        {
            //increase score of  players other than 4
            scoreP3();
            scoreP2();
            scoreP1();
            StartCoroutine(RespawnBall(2));
        }
        else if (collision.gameObject.CompareTag("topBorder"))
        {
            //increase score of  players other than 3
            scoreP4();
            scoreP2();
            scoreP1();
            StartCoroutine(RespawnBall(2));
        }
        

        previousDirection = ballRB.velocity.normalized;
    }

    public void scoreP1()
    {
        StatManager.Instance.incrementScoreP1();
    }

    public void scoreP2()
    {
        StatManager.Instance.incrementScoreP2();
    }

    public void scoreP3()
    {
        StatManager.Instance.incrementScoreP3();
    }

    public void scoreP4()
    {
        StatManager.Instance.incrementScoreP4();
    }
}


