using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle1;
    [SerializeField] float velocityX = 0f, velocityY = 15f;
    [SerializeField] AudioClip [] soundClip;
    [SerializeField] float randomFactor = 0.1f;
    AudioSource audioSourceStart;
    Rigidbody2D rigidBody2D;

    Vector2 paddleToTheBallVector;
    bool hasStarted = false;


    // Start is called before the first frame update
    void Start()
    {
        paddleToTheBallVector = transform.position - paddle1.transform.position;
        audioSourceStart = GetComponent<AudioSource>();
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hasStarted == false)
        {
            paddleLock();
            paddleThrow();
        }
        
    }

    private void paddleThrow()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(velocityX, velocityY);
            hasStarted = true;
        }
    }

    private void paddleLock()
    {
        Vector2 paddlepos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);

        transform.position = paddlepos + paddleToTheBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStarted)
        {
           // AudioClip ballSound = soundClip[UnityEngine.Random.Range(0, soundClip.Length)];
           // audioSourceStart.PlayOneShot(ballSound);
        }
        rigidBody2D.velocity += new Vector2(randomFactor, randomFactor);
    }
}
