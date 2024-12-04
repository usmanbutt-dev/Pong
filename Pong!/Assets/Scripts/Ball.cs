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
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collision) {
        HandleCollision(collision);
    }

    private void HandleCollision(Collision2D collision) {
        if (collision.gameObject.CompareTag("Wall")) {
            audioSource.PlayOneShot(wallHitSound);
        }
        else if (collision.gameObject.CompareTag("Paddle")) {
            audioSource.PlayOneShot(paddleHitSound);
            SetRandomVerticalVelocity();
        }
        else if (collision.gameObject.CompareTag("RightBorder")) {
            gameController.AddPoint(1);  // Player 1 scores
            gameController.TriggerPointScored();
        }
        else if (collision.gameObject.CompareTag("LeftBorder")) {
            gameController.AddPoint(2);  // Player 2 scores
            gameController.TriggerPointScored();
        }
    }

    // Sets the vertical velocity to a random value within a range
    private void SetRandomVerticalVelocity() {
        float yVelocity = Random.Range(-1.5f, 1.5f);
        rb.velocity = new Vector2(rb.velocity.x, yVelocity * startingSpeed);
    }

    // Reset ball to the center and apply a random velocity
    public void ResetBall() {
        rb.velocity = Vector2.zero;  // Stop any existing movement
        Vector2 randomDirection = GetRandomDirection();
        rb.velocity = randomDirection * startingSpeed;
        transform.position = Vector2.zero;  // Reset position to center
    }

    // Generates a random direction (horizontal and vertical)
    private Vector2 GetRandomDirection() {
        float xVelocity = Random.Range(0f, 1f) > 0.5f ? 1f : -1f;
        float yVelocity = Random.Range(-1.5f, 1.5f);
        return new Vector2(xVelocity, yVelocity);
    }
}
