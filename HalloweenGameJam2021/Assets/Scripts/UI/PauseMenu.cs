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
        sc = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
                sc.PauseAudioStop();
            }
            else
            {
                Pause();               
                sc.PauseAudio();
            }
        }
    }

    public void Resume()
    {
        pauseGameUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        
    }

    public void Pause()
    {
        pauseGameUI.SetActive(true);
        pauseGameUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        
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
            audioOnButton.SetActive(false);
            audioOffButton.SetActive(true);
            
            //music off
            audioOn = false;
            sc.MuteMusic();
            
        }
        else
        {
            audioOnButton.SetActive(true);
            audioOffButton.SetActive(false);
            
            //music on
            audioOn = true;
            sc.MuteMusicStop();
            
        }
    }
}
