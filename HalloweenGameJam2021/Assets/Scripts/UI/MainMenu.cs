using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Animator SceneAnimator;
    [SerializeField] private GameObject SceneTransition;
    
  
    public void Play()
    {
        SceneTransition.SetActive(true);
        SceneAnimator.Play("Scene_Transition_Enter");
    }
    
    public void Quit()
    {
        Application.Quit();
    }
    
    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
    }
}
