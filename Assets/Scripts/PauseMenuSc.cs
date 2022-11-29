using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuSc : MonoBehaviour
{
    public bool isGamePaused = false;
    public GameObject pauseMenu;
    private bool validate = true;

    void Start() {
        Resume();   // Oyun ilk acildiginda Pause menusunun acilmamasi icin 
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw("Pause") == 1 && validate) {
            validate = false;
            if(isGamePaused == true) {
                Resume();
            } else {
                Pause();
            }
        }
        else if(Input.GetAxisRaw("Pause") == 0){
            validate = true;
        }
    }

    // Pause the game and bring the pause menu.
    public void Pause() {
        pauseMenu.SetActive(true);
        Time.timeScale  = 0.0001f;         // timeScale == 0f --> game is paused, timeScale == 1.0f --> time passes as fast as realtime
        isGamePaused = true;
    }
    public void Resume() {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }
    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}