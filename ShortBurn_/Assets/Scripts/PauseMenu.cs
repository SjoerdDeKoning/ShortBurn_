using System;
using System.Collections;
using System.Collections.Generic;
using Player_Controls;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public bool _gameIsPaused = false;
    
    [SerializeField] private GameObject pauseMenuUi;
    
    [SerializeField] private InputManager inputManager ;

    

    void Update()
    {
        //game is paused yes or no?
        if (inputManager.Escape())
        {
            if (_gameIsPaused)
                Resume();
            else
                Pause();
        }
    }

    //No? then it will continue on this code:
    public void Resume()
    {
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        _gameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    //Yes? then it will pause on this code:
    public void Pause()
    {
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        _gameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
