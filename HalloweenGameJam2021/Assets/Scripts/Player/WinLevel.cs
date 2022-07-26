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
    [SerializeField] private GameObject SceneTransitionHolder;
    
    [SerializeField] private GameObject player;
    [SerializeField] private InputController myInputController;
    [SerializeField] private Rigidbody2D rb; 

    private void Awake()
    {
        cardCounter = 0;
        count = 0;
        cardsToWin = 0;
        sceneTransition = GameObject.FindWithTag("Scene_Transition").GetComponent<Animator>();
        SceneTransitionHolder = GameObject.FindWithTag("Scene_Transition");
        
        player = GameObject.FindGameObjectWithTag("Player");
        myInputController = player.GetComponent<InputController>();
        rb = player.GetComponent<Rigidbody2D>();
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
            myInputController.MoveInput = 0f;
            myInputController.FlyInput = false;
            player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            rb.constraints = RigidbodyConstraints2D.FreezePosition;
            SceneTransitionHolder.SetActive(true);
            sceneTransition.Play("Scene_Transition_Enter");
        }
    }
}
