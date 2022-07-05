using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DestryCard : MonoBehaviour
{
    [SerializeField] private Animator card;

    private void Awake()
    {
        card = this.GameObject().GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            card.SetTrigger("Collected");
            //Destroy(other.gameObject);
            Destroy(this.GetComponentInChildren<Light2D>());
            Destroy(this.transform.Find("Light 2D (1)").GetComponentInChildren<Light2D>());
            Destroy(this.transform.Find("Light 2D (2)").GetComponentInChildren<Light2D>());
            WinLevel.cardCounter++;
        }
    }
    private void DestroyCard()
    {
        Destroy(this.gameObject);
    }
}
