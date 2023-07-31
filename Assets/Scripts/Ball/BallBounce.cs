using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounce : MonoBehaviour
{
    private BallMovement ballM;
    private Rigidbody2D ballRB;
    // Start is called before the first frame update
    void Start()
    {
        ballM = GetComponent<BallMovement>();
        ballRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
