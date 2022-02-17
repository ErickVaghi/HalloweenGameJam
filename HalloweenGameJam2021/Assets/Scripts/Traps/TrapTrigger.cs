using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
public class TrapTrigger : MonoBehaviour
{
    [SerializeField] private Light2D myLight2D;
    [SerializeField] private DeathTimer deathTimer;
    [SerializeField] private GameObject player;
    //public Transform currentPosition { get; private set; }
    //[SerializeField] private InputController myInputController;

    public bool isDead;

    private void Start()
    {
        isDead = false;
        deathTimer.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //currentPosition.position = player.transform.position;
        player.GetComponent<SpriteRenderer>().enabled = false;
        //myInputController.enabled = false;
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
