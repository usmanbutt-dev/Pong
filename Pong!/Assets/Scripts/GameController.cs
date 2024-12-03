using System.Collections;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour {
    public GameObject ball;
    public TextMeshProUGUI startButtonText;
    public TextMeshProUGUI startTimeText;
    private bool gameStarted = false;
    private bool isPaused = false;
    public bool pointScored = false;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && !gameStarted) {
            startButtonText.enabled = false;
            startTimeText.enabled = true;
            StartCoroutine(StartCountdown());
            gameStarted = true;
        }

        if(pointScored) {
            ball.SetActive(false);
            gameStarted = false;
            startButtonText.enabled = true;
            pointScored = false;
        }

        if (Input.GetKeyDown(KeyCode.P) && gameStarted) {
            if (isPaused) {
                ResumeGame();
            }
            else {
                PauseGame();
            }
        }
    }

    IEnumerator StartCountdown() {
        for (int i = 3; i > 0; i--) {
            startTimeText.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }
        startTimeText.enabled = false;
        ball.SetActive(true);
    }

    void PauseGame() {
        Time.timeScale = 0f;
        isPaused = true;
    }

    void ResumeGame() {
        Time.timeScale = 1f;
        isPaused = false;
    }
}
