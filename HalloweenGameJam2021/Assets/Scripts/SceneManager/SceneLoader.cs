using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private Animator SceneAnimator;
    private void Awake()
    {
        SceneAnimator = gameObject.GetComponent<Animator>();
        SceneAnimator.Play("Scene_Transition_Exit");
    }

    public void LoadNextScene()
    {
        WinLevel.count = 0;
        WinLevel.cardCounter = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
    }
}
