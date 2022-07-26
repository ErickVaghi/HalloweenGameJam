
using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
public class TrapTrigger : MonoBehaviour
{
    [Header("Trap's Components")] [SerializeField]
    private Light2D myLight2D;

    //public Transform currentPosition { get; private set; }
    [Header("Player's Attributes")] [SerializeField]
    private InputController myInputController;

    [SerializeField] private GameObject player;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private Rigidbody2D playerRigidBody;
    [SerializeField] private CommandContainer commandContainer;

    [Header("Respawn")] public Transform respawn;

    [Header("UI")] [SerializeField] private Animator transition;

    //[Header("Bool")] public static bool isDead;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerRigidBody = player.GetComponent<Rigidbody2D>();
        playerAnimator = player.GetComponent<Animator>();
        myInputController = player.GetComponent<InputController>();
        commandContainer = player.GetComponent<CommandContainer>();

        //Connect transition component
        transition = GameObject.FindGameObjectWithTag("Transition").GetComponent<Animator>();

        //Connect Checkpoint Object
        respawn = GameObject.FindGameObjectWithTag("CheckPoint").GetComponent<Transform>();

        //deathTimer = this.GetComponent<DeathTimerKids>();
        myLight2D = this.GetComponentInChildren<Light2D>();
    }

    private void Start()
    {
        Respawn.isDead = false;
        //deathTimer.enabled = false;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!DashController.isDashing)
        {
            //stop the player from moving
            //currentPosition.position = player.transform.position;
            myInputController.MoveInput = 0f;
            commandContainer.moveCommand = 0f;
            myInputController.FlyInput = false;
            commandContainer.flyCommand = false;
            myInputController.enabled = false;
            playerRigidBody.velocity = Vector2.zero;

            CameraShake.Instance.ShakeCamera(6f, .8f);

            playerAnimator.Play("Death");

            //Play transition animation
            transition.SetTrigger("Transition");

            //disable Collider to avoid extra collisions with the kid
            player.GetComponent<Collider2D>().enabled = false;
            Respawn.isDead = true;
        }
    }

    private void Update()
    {
        if (!Respawn.isDead)
        {
            //deathTimer.enabled = false;
            commandContainer.moveCommand = myInputController.MoveInput;
        }
        else
        {
            playerRigidBody.velocity = Vector2.zero;
        }
    }
}
