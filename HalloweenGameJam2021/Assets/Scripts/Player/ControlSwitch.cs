using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSwitch : MonoBehaviour
{
    [SerializeField] private InputController myInputController;
    private void Awake()
    {
        myInputController = gameObject.GetComponent<InputController>();
    }

    void Update()
    {
        
    }

    public void TurnOnControlls()
    {
        myInputController.enabled = true;
    }
}
