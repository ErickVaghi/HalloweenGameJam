using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] private GameObject Animation;
    [SerializeField] private Animator CpAnimation;

    private void Awake()
    {
        //Animation.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Animation.SetActive(true);
        CpAnimation.SetTrigger("Checkpoint");
    }
}
