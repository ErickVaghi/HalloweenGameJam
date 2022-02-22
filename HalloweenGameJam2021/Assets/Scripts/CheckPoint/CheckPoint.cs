using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] private Animator CpAnimation;
    public bool checkPointActive;
    public Transform newRespawn;
    [SerializeField] private DeathTimer myDeathTimer;

    private void Awake()
    {
        newRespawn = gameObject.GetComponent<Transform>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!checkPointActive)
        {
            CpAnimation.SetTrigger("Checkpoint");
            checkPointActive = true;
            myDeathTimer.respawn.position = newRespawn.position;
        }
    }
}