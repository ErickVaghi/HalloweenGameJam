using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class WinLevel : MonoBehaviour
{
    public static int cardCounter = 0;
    [SerializeField] private int count;
    [SerializeField] private int cardsToWin = 3;

    private void Update()
    {
        count = cardCounter;
        if (cardCounter >= cardsToWin)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}