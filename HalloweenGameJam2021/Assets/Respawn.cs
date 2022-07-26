using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Respawn : MonoBehaviour
{
    [Header("Trap's Components")]
    [SerializeField] private Light2D myLight2D;

    //public Transform currentPosition { get; private set; }
    [Header("Player's Attributes")]
    [SerializeField] private InputController myInputController;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private Rigidbody2D playerRigidBody;
    [SerializeField] private CommandContainer commandContainer;
    
    [Header("Respawn")]
    public Transform respawn;
    
    [Header("UI")]
    [SerializeField] private Animator transition;
    
    [Header("Bool")] public static bool isDead;
    
    private void Awake()
    {
        playerRigidBody = gameObject.GetComponent<Rigidbody2D>();
        playerAnimator = gameObject.GetComponent<Animator>();
        myInputController = gameObject.GetComponent<InputController>();
        commandContainer = gameObject.GetComponent<CommandContainer>();
        
        //Connect transition component
        transition = GameObject.FindGameObjectWithTag("Transition").GetComponent<Animator>();
        
        //Connect Checkpoint Object
        respawn = GameObject.FindGameObjectWithTag("CheckPoint").GetComponent<Transform>();
        
        //deathTimer = this.GetComponent<DeathTimerKids>();
        myLight2D = this.GetComponentInChildren<Light2D>();
    }
    
    public void RespawnPlayer()
    {
        playerAnimator.Play("Ghost Idle");
        playerRigidBody.velocity = Vector2.zero;
        transform.position = respawn.position;
        this.GetComponent<Collider2D>().enabled = true;
        myLight2D.enabled = true;
        isDead = false;
        playerRigidBody.velocity = Vector2.zero;
        myInputController.enabled = true;
    }
}
