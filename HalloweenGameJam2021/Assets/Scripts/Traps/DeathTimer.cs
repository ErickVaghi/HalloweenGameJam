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
    
    //[SerializeField] private GameObject deathParticles;
    private bool deathAnimation = false;

    private void Awake()
    {
        //deathParticles.SetActive(false);
    }

    private void Start()
    {
        deathAnimation = false;
        deathTimeCounter = deathTime;
    }

    public void Update()
    {
        HandeDeath();
    }

    void HandeDeath()
    {
        if (!deathAnimation)
        {
            //deathParticles.transform.position = player.transform.position;
            //deathParticles.SetActive(true);
            //Destroy(player);
            deathAnimation = true;
        }
        deathTimeCounter -= Time.deltaTime;
        if (deathTimeCounter < 0 && myTrapTrigger.isDead)
        {
            deathTimeCounter = deathTime;
            player.transform.position = respawn.position;
            player.GetComponent<SpriteRenderer>().enabled = true;
            myLight2D.enabled = true;
            myTrapTrigger.isDead = false;
            myRigidBody.velocity = Vector2.zero;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
