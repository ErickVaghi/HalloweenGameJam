using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathTimer : MonoBehaviour
{
    [SerializeField] private float deathTimeCounter;
    [SerializeField] private float deathTime = 10f;
    [SerializeField] private GameObject player;
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
        if (!deathAnimation)
        {
            //deathParticles.transform.position = player.transform.position;
            //deathParticles.SetActive(true);
            Destroy(player);
            deathAnimation = true;
        }
        deathTimeCounter -= Time.deltaTime;
        if (deathTimeCounter < 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
