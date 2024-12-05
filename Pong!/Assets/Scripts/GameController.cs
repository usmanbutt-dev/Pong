using System.Collections;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour {
    public GameObject ball;
    public TextMeshProUGUI startButtonText;
    public TextMeshProUGUI startTimeText;
    public TextMeshProUGUI scoreText;
    public GameObject pauseCanvas;

    private bool gameStarted = false;
    private bool isPaused = false;
    private bool waitingForRestart = false;

    // Track scores for both players
    private int player1Score = 0;
    private int player2Score = 0;

    private void Awake() {
        Time.timeScale = 1f;
    }
    void Update() {
        UpdateScoreDisplay();

        if (!gameStarted && !waitingForRestart && Input.GetKeyDown(KeyCode.Space)) {
            StartGame();
        }

        // Wait for spacebar press after point is scored
        if (waitingForRestart && Input.GetKeyDown(KeyCode.Space)) {
            waitingForRestart = false;  // Reset flag
            StartCoroutine(StartCountdown());
        }

        if (Input.GetKeyDown(KeyCode.Escape) && gameStarted) {
            TogglePause();
        }
    }

    // Update score display every frame before the game starts
    private void UpdateScoreDisplay() {
        if (!gameStarted && !waitingForRestart) {
            scoreText.text = $"{player1Score} - {player2Score}";
        }
    }

    // Starts the game and triggers countdown
    private void StartGame() {
        startButtonText.enabled = false;
        startTimeText.enabled = true;
        StartCoroutine(StartCountdown());
        gameStarted = true;
    }

    // Starts countdown before restarting the round
    private IEnumerator StartCountdown() {
        startButtonText.enabled = false;
        startTimeText.enabled = true;
        for (int i = 3; i > 0; i--) {
            startTimeText.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }
        startTimeText.enabled = false;
        scoreText.enabled = false;
        ball.SetActive(true);
        Ball ballScript = ball.GetComponent<Ball>();
        ballScript.ResetBall();  // Call method to reset the ball's velocity and direction
    }

    // Handle point scoring
    public void AddPoint(int playerNumber) {
        if (playerNumber == 1) {
            player1Score++;
        }
        else if (playerNumber == 2) {
            player2Score++;
        }
        scoreText.text = $"{player1Score} - {player2Score}";
    }

    // Triggered after a point is scored, preparing for next round
    public void TriggerPointScored() {
        ball.SetActive(false);  // Deactivate the ball
        startButtonText.enabled = true;
        scoreText.enabled = true;
        ball.transform.position = Vector2.zero;  // Reset position
        waitingForRestart = true;  // Wait for spacebar press
    }

    // Toggle pause state of the game
    private void TogglePause() {
        if (isPaused) {
            ResumeGame();
        }
        else {
            PauseGame();
        }
    }

    // Pause the game
    private void PauseGame() {
        pauseCanvas.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    // Resume the game
    private void ResumeGame() {
        pauseCanvas.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
}
