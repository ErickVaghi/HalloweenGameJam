using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class DeathTimer : MonoBehaviour
{
    [Header("Trap's Components")]
    [SerializeField] private Light2D myLight2D;
    [SerializeField] private TrapTrigger myTrapTrigger;
    
    [Header("Death Timer")]
    [SerializeField] private float deathTimeCounter;
    [SerializeField] private float deathTime = 10f;
    
    [Header("Player's Components")]
    [SerializeField] private GameObject player;
    [SerializeField] private InputController playerInputController;
    [SerializeField] private Rigidbody2D playerRigidBody;
    [SerializeField] private Animator playerAnimator;
    
    [Header("Respawn")]
    public Transform respawn;
    
    //[SerializeField] private GameObject deathParticles;
    //private bool deathAnimation = false;
    
    private void Awake()
    {
        myLight2D = this.GetComponentInChildren<Light2D>();
        myTrapTrigger = this.GetComponent<TrapTrigger>();
        
        player = GameObject.FindGameObjectWithTag("Player");
        playerInputController = player.GetComponent<InputController>();
        playerAnimator = player.GetComponent<Animator>();
        playerRigidBody = player.GetComponent<Rigidbody2D>();

        respawn = GameObject.FindGameObjectWithTag("CheckPoint").GetComponent<Transform>();

        //deathParticles.SetActive(false);
    }

    private void Start()
    {
        //deathAnimation = false;
        deathTimeCounter = deathTime;
    }

    public void Update()
    {
        HandleDeath();
    }

    void HandleDeath()
    {
        playerRigidBody.velocity = Vector2.zero;
        deathTimeCounter -= Time.deltaTime;
        //player.transform.position = myTrapTrigger.currentPosition.position;
        if (deathTimeCounter < 0 && myTrapTrigger.isDead)
        {
            playerAnimator.ResetTrigger("Dead");
            playerAnimator.SetTrigger("Alive");
            
            deathTimeCounter = deathTime;
            player.transform.position = respawn.position;
            //player.GetComponent<SpriteRenderer>().enabled = true;
            player.GetComponent<Collider2D>().enabled = true;
            myLight2D.enabled = true;
            myTrapTrigger.isDead = false;
            playerRigidBody.velocity = Vector2.zero;
            playerInputController.enabled = true;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
