using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public Canvas menu;
    public Button playButton;
    public Button exitButton;

    void Start()
    {
        playButton = playButton.GetComponent<Button>();
        exitButton = exitButton.GetComponent<Button>();
        menu.enabled = false;
    }

    public void mainScreen()
    {
        SceneManager.LoadScene("StartMenu");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M) == true)
        {
            if (menu.enabled == true)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
        if (menu.enabled == true)
        {
            Time.timeScale = 0;
            if (Input.GetKeyDown(KeyCode.Q) == true)
            {
                /*mainScreen();
                Time.timeScale = 1;*/
                Quit();
            }
            if (Input.GetKeyDown(KeyCode.R) == true)
            {
                /*menu.enabled = false;
                Time.timeScale = 1;*/
                Resume();
            }
        }
    }

    public void Resume()
    {
        menu.enabled = false;
        Time.timeScale = 1;
    }

    public void Pause()
    {
        menu.enabled = true;
        Time.timeScale = 0;
    }

    public void Quit()
    {
        mainScreen();
        Time.timeScale = 1;
        //Application.Quit();
    }
}
