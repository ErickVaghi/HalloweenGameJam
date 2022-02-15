using UnityEngine;

public class FlyController : MonoBehaviour
{
    [SerializeField] private CommandContainer myControlContainer;
    [SerializeField] private Rigidbody2D myRigidbody2D;
    [SerializeField] private float flyForce = 5f;
    [SerializeField] private float maxForce = 20f;

    private void Update()
    {
        if (myControlContainer.flyCommand && myRigidbody2D.velocity.y <= maxForce)
        {
            myRigidbody2D.AddForce(Vector2.up*flyForce);
        }
    }
}
