using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickUpCard : MonoBehaviour
{
    [SerializeField] private int cardCounter = 0;
    [SerializeField] private Animator card;

    private void Awake()
    {
        card = GameObject.FindGameObjectWithTag("Card").GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Card"))
        {
            card.SetTrigger("Collected");
            //Destroy(other.gameObject);
            cardCounter++;
        }
    }
    
}
