using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class WinLevel : MonoBehaviour
{
    public static int cardCounter = 0;
    public static int count;
    public static int cardsToWin = 3;
    [SerializeField] private Animator sceneTransition;

    private void Awake()
    {
        sceneTransition = GameObject.FindWithTag("Scene_Transition").GetComponent<Animator>();
    }

    private void Update()
    {
        count = cardCounter;
        if (cardCounter >= cardsToWin)
        {
            sceneTransition.Play("Scene_Transition_Enter");
        }
    }
}
