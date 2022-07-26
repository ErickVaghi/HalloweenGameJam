using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] private Animator CpAnimation;
    public bool checkPointActive;
    public Transform newRespawn;
    //[SerializeField] private DeathTimer myDeathTimer;

    public SoundController sc;

    private void Awake()
    {
        newRespawn = gameObject.GetComponent<Transform>();
        //myDeathTimer = GameObject.FindWithTag("Trap").GetComponent<DeathTimer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!checkPointActive)
        {
            CpAnimation.SetTrigger("Checkpoint");
            checkPointActive = true;
            Respawn.respawn.position = newRespawn.position;
            //myDeathTimer.respawn.position = newRespawn.position;
            sc.ChekpointAudio();
        }
    }
}
