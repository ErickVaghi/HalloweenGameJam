using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSwitch : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private InputController myInputController;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        myInputController = player.GetComponent<InputController>();
    }
    
    public void TurnOnControls()
    {
        //player.GetComponent<InputController>().enabled = true;
        myInputController.enabled = true;
    }
}
