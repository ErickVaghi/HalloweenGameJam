using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public SoundController sc;

    public static bool GameIsPaused = false;
    [SerializeField] private GameObject PauseGameUI;

    private void Awake()
    {
        PauseGameUI = GameObject.Find("Pause Menu");
        PauseGameUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
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
        PauseGameUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        sc.PauseAudioStop();
    }

    public void Pause()
    {
        PauseGameUI.SetActive(true);
        PauseGameUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        sc.PauseAudio();
    }

    public void Quit()
    {
        //Debug.Log("Quitting Game");
        Application.Quit();
    }
}
