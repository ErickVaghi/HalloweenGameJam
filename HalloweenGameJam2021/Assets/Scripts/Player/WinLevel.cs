using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class WinLevel : MonoBehaviour
{
    [SerializeField] public static int cardCounter = 0;
    [SerializeField] public static int count;
    [SerializeField] private int MaxCards;
    [SerializeField] public static int cardsToWin;
    [SerializeField] private Animator sceneTransition;

    private void Awake()
    {
        cardCounter = 0;
        count = 0;
        cardsToWin = 0;
        sceneTransition = GameObject.FindWithTag("Scene_Transition").GetComponent<Animator>();
    }

    private void Start()
    {
        cardCounter = 0;
        count = 0;
        cardsToWin = 0;
        cardsToWin = MaxCards;
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
