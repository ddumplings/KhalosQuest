using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerMenu : MonoBehaviour {

    public static bool isPaused;

    public Canvas menu;
    public Button playButton;

    void Start()
    {
        playButton = playButton.GetComponent<Button>();
        menu.enabled = false;
        isPaused = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) == true && !PauseMenu.isPaused)
        {
            if (menu.enabled == true)
            {
                Resume();
            }
            else
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
}