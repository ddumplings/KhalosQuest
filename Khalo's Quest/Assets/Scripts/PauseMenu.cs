﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused;

    public Canvas menu;
    public Button playButton;
    public Button exitButton;

    void Start()
    {
        playButton = playButton.GetComponent<Button>();
        exitButton = exitButton.GetComponent<Button>();
        menu.enabled = false;
        isPaused = false;
    }

    public void mainScreen()
    {
        SceneManager.LoadScene("StartMenu");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M) == true && !PlayerMenu.isPaused)
        {
            if (menu.enabled == true)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        menu.enabled = false;
        isPaused = false;
        Time.timeScale = 1;
    }

    public void Pause()
    {
        menu.enabled = true;
        isPaused = true;
        Time.timeScale = 0;
    }

    public void Quit()
    {
        Resume();
        mainScreen();
        //Application.Quit();
    }
}