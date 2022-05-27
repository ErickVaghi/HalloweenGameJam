using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
public class TrapTrigger : MonoBehaviour
{
    [Header("Trap's Components")]
    [SerializeField] private Light2D myLight2D;
    [SerializeField] private DeathTimer deathTimer;
    
    //public Transform currentPosition { get; private set; }
    [Header("Player's Attributes")]
    [SerializeField] private InputController myInputController;
    [SerializeField] private GameObject player;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private CommandContainer commandContainer;

    [Header("-")]
    public bool isDead;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerAnimator = player.GetComponent<Animator>();
        myInputController = player.GetComponent<InputController>();
        commandContainer = player.GetComponent<CommandContainer>();
        
        deathTimer = this.GetComponent<DeathTimer>();
        myLight2D = this.GetComponentInChildren<Light2D>();
    }
    private void Start()
    {
        isDead = false;
        deathTimer.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!DashController.isDashing)
        {
            //currentPosition.position = player.transform.position;
            myInputController.MoveInput = 0f;
            commandContainer.moveCommand = 0f;
            myInputController.enabled = false;
            player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        
            /*player.GetComponent<SpriteRenderer>().enabled = false;
            myLight2D.enabled = false;*/
        
            CameraShake.Instance.ShakeCamera(6f, .8f);

            playerAnimator.SetTrigger("Dead");
            playerAnimator.ResetTrigger("Alive");
            player.GetComponent<Collider2D>().enabled = false;
            isDead = true;
            deathTimer.enabled = true;
        }
    }

    private void Update()
    {
        if(!isDead)
        {
            deathTimer.enabled = false;
            commandContainer.moveCommand = myInputController.MoveInput;
        }
    }
}
