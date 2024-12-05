using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Awake() {
        Time.timeScale = 1f;
    }

    public void QuitGame() {
        Application.Quit();
    }
    public void LoadMainMenu() {
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadPlayerVSCPU() {
        SceneManager.LoadScene("PVCPU");
    }
    public void LoadPlayerVSPlayer() {
        SceneManager.LoadScene("PVP");
    }
}
