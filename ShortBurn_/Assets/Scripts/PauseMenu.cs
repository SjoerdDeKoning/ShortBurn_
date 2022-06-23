using System;
using System.Collections;
using System.Collections.Generic;
using Control_and_Input;
using Player_Controls;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool _gameIsPaused = false;
    
    [SerializeField] private GameObject pauseMenuUiCold;
    [SerializeField] private GameObject pauseMenuUiWarm;
    
    [SerializeField] private InputManager inputManager ;

    public bool isWinter;

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
        pauseMenuUiCold.SetActive(false);
        pauseMenuUiWarm.SetActive(false);
        Time.timeScale = 1f;
        _gameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    //Yes? then it will pause on this code:
    public void Pause()
    {
        if (isWinter)
        {
            pauseMenuUiCold.SetActive(true);
        }
        else
        {
            pauseMenuUiWarm.SetActive(true);
        }
        
        Time.timeScale = 0f;
        _gameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
    }

    //Put in the scene name in the button to get it momving to the scene.
    //Remember to put your scene als in the build settings other wise it wont work
    public void LoadScene(string Scene)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(Scene);
    }

    //Exit game when is clicked on Exit
    public void ExitGame()
    {
        Time.timeScale = 1f;
        Debug.Log("Test");
        Application.Quit();
    }
    
}
