using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private float startSpeed;
    [SerializeField] private float incrementFactor;
    [SerializeField] private float maxSpeed;
    [SerializeField] private int hits = 0;

    public ParticleSystem particleSystem;
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
        Move(new Vector2(-10, 0));
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


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 directionHit = collision.GetContact(0).normal;
        Vector2 clampDirection = Vector2.ClampMagnitude(directionHit, 0.8f);
       // Debug.Log(string.Format("direction Hit : {1} and prev direction : {0}, comp : {2}", previousDirection, directionHit, new Vector2(-directionHit.x, -directionHit.y)));
        //if (previousDirection == new Vector2(-directionHit.x,-directionHit.y))

        //do particle spawning here
        //particleSpawner.SpawnParticlesAt(collision.GetContact(0).point);

        if (previousDirection == new Vector2(-directionHit.x,-directionHit.y))
        {
           // Debug.Log("same direction hit ");
            sameDirectionHit++;
        }

        if (collision.gameObject.CompareTag("racket") && ((incrementFactor * hits * Time.deltaTime) + ballRB.velocity.magnitude) < maxSpeed)
        {
            //play hit sound
            AudioManager.Instance.Play("BallHitWall");
            //handle particle spawn
            Debug.Log(string.Format("collison position {0}", collision.transform.position));
            particleSystem.transform.Translate(collision.transform.position);
            particleSystem.Play();

            hits ++;
            //Debug.Log("direction: "+directionHit);
            //Debug.Log("previous velocity : " + ballRB.velocity);
            //Debug.Log("increment factor : " + (incrementFactor * hits));

            //using contact normal
            Vector2 contactNormal = collision.GetContact(0).normal;
            //Debug.Log("contact normal : " + contactNormal);

            // Calculate the new direction based on the collision point
            Vector2 collisionPoint = collision.GetContact(0).point;
            Vector2 racketCenter = collision.gameObject.transform.position;
            Vector2 direction = collisionPoint - racketCenter;
            direction.Normalize();

            // Update the ball's velocity with the new direction and increased speed
            ballRB.velocity = clampDirection * (ballRB.velocity.magnitude + (incrementFactor * hits * Time.deltaTime));

            //ballRB.velocity = ballRB.velocity.normalized * ((incrementFactor * hits * Time.deltaTime) + ballRB.velocity.magnitude); //inverse direction of hit
            //ballRB.velocity = Vector2.Reflect(ballRB.velocity, contactNormal);
            //Debug.Log("reflected contact normal : " + Vector2.Reflect(ballRB.velocity, contactNormal));
           // Debug.Log("hits : "+hits);
            //Debug.Log("new velocity : "+ballRB.velocity);
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

       /* if (sameDirectionHit > 2)
        {
            Debug.Log("trigger random direction");
            //give random direction
            ballRB.velocity = new Vector2(Random.Range(-1.0f,1.0f), Random.Range(-1.0f, 1.0f)) * ballRB.velocity.magnitude;
            sameDirectionHit = 0;
        }*/
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


