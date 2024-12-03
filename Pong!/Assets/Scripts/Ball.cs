using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    public GameController gameController;
    public Rigidbody2D rb;
    public float startingSpeed;

    // Audio variables
    public AudioClip wallHitSound;
    public AudioClip paddleHitSound;
    private AudioSource audioSource;

    void Start() {
        transform.position = new Vector2(0f, 0f);
        audioSource = GetComponent<AudioSource>();
        bool isRight = UnityEngine.Random.value >= 0.5f;
        float xVelocity = -1f;

        if (isRight) {
            xVelocity = 1f;
        }

        float yVelocity = UnityEngine.Random.Range(-1.5f, 1.5f);
        rb.velocity = new Vector2(xVelocity * startingSpeed, yVelocity * startingSpeed);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Wall")) {
            audioSource.PlayOneShot(wallHitSound);
        }
        if (collision.gameObject.CompareTag("Paddle")) {
            audioSource.PlayOneShot(paddleHitSound);
            float yVelocity = UnityEngine.Random.Range(-1.5f, 1.5f);
            rb.velocity = new Vector2(rb.velocity.x, yVelocity * startingSpeed);
        }

        if (collision.gameObject.CompareTag("RightBorder")) {
            //Player 1 winning condition
            gameController.pointScored = true;
        }
        if (collision.gameObject.CompareTag("LeftBorder")) {
            //Player 2 winning condition
            gameController.pointScored = true;
        }
    }
}