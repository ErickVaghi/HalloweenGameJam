using UnityEngine;

public class FlyController : MonoBehaviour
{
    [SerializeField] private CommandContainer myControlContainer;
    [SerializeField] private Rigidbody2D myRigidbody2D;
    [SerializeField] private float flyForce = 5f;
    [SerializeField] private float maxForce = 20f;

    private void FixedUpdate()
    {
        if (myControlContainer.flyCommand && myRigidbody2D.velocity.y <= maxForce)
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.5f;
            myRigidbody2D.AddForce((Vector2.up*flyForce) * Time.deltaTime);
        }
        else
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 1.1f;
    }
}
