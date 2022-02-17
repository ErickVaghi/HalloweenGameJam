using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class DeathTimer : MonoBehaviour
{
    [SerializeField] private Light2D myLight2D;
    [SerializeField] private float deathTimeCounter;
    [SerializeField] private float deathTime = 10f;
    [SerializeField] private GameObject player;
    [SerializeField] private Transform respawn;

    [SerializeField] private TrapTrigger myTrapTrigger;

    [SerializeField] private Rigidbody2D myRigidBody;

    [SerializeField] private Animator myAnimator;

    [SerializeField] private InputController myInputController;
    
    //[SerializeField] private GameObject deathParticles;
    //private bool deathAnimation = false;

    private void Awake()
    {
        //deathParticles.SetActive(false);
    }

    private void Start()
    {
        //deathAnimation = false;
        deathTimeCounter = deathTime;
    }

    public void Update()
    {
        HandeDeath();
    }

    void HandeDeath()
    {
        myRigidBody.velocity = Vector2.zero;
        deathTimeCounter -= Time.deltaTime;
        //player.transform.position = myTrapTrigger.currentPosition.position;
        if (deathTimeCounter < 0 && myTrapTrigger.isDead)
        {
            myAnimator.ResetTrigger("Dead");
            myAnimator.SetTrigger("Alive");
            deathTimeCounter = deathTime;
            player.transform.position = respawn.position;
            //player.GetComponent<SpriteRenderer>().enabled = true;
            player.GetComponent<Collider2D>().enabled = true;
            myLight2D.enabled = true;
            myTrapTrigger.isDead = false;
            myRigidBody.velocity = Vector2.zero;
            myInputController.enabled = true;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
