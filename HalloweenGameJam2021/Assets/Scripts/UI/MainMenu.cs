using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Animator SceneAnimator;
    [SerializeField] private GameObject SceneTransition;
    [SerializeField] private bool audioOn = true;
    [SerializeField] private GameObject audioOnButton;
    [SerializeField] private GameObject audioOffButton;
  
    public void Play()
    {
        SceneTransition.SetActive(true);
        SceneAnimator.Play("Scene_Transition_Enter");
    }
    
    public void PlayGameAgain()
    {
        SceneTransition.SetActive(true);
        SceneAnimator.Play("Scene_Transition_Enter_End_Scene");
    }
    
    public void Quit()
    {
        Application.Quit();
    }
    
    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
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
