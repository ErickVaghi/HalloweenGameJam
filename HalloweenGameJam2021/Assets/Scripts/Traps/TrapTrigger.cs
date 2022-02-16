using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
public class TrapTrigger : MonoBehaviour
{
    [SerializeField] private Light2D myLight2D;
    [SerializeField] private DeathTimer deathTimer;
    [SerializeField] private GameObject player;

    public bool isDead;

    private void Start()
    {
        isDead = false;
        deathTimer.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        player.GetComponent<SpriteRenderer>().enabled = false;
        myLight2D.enabled = false;
        isDead = true;
        deathTimer.enabled = true;
    }

    private void Update()
    {
        if(!isDead)
        {
            deathTimer.enabled = false;
        }
    }
}
