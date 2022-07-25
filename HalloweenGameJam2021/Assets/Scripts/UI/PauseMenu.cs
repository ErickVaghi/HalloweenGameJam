using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public SoundController sc;

    public static bool GameIsPaused = false;
    [SerializeField] private GameObject pauseGameUI;
    [SerializeField] private bool audioOn = true;
    [SerializeField] private GameObject audioOnButton;
    [SerializeField] private GameObject audioOffButton;

    private void Awake()
    {
        pauseGameUI = GameObject.Find("Pause Menu");
        pauseGameUI.SetActive(false);
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
        pauseGameUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        sc.PauseAudioStop();
    }

    public void Pause()
    {
        pauseGameUI.SetActive(true);
        pauseGameUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        sc.PauseAudio();
    }

    public void Quit()
    {
        //Debug.Log("Quitting Game");
        Application.Quit();
    }

    public void SwitchAudio()
    {
        if (audioOn)
        {
            audioOn = false;
            audioOnButton.SetActive(false);
            audioOffButton.SetActive(true);
        }
        else
        {
            audioOn = true;
            audioOnButton.SetActive(true);
            audioOffButton.SetActive(false);
        }
    }
}
