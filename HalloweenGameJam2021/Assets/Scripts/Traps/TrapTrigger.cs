using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TrapTrigger : MonoBehaviour
{
    [SerializeField] private DeathTimer deathTimer;

    private void Start()
    {
        deathTimer.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        deathTimer.enabled = true;
    }
}
