using UnityEngine;

public class FlyController : MonoBehaviour
{
    [SerializeField] private ControlContainer myControlContainer;
    [SerializeField] private Rigidbody2D myRigidbody2D;
    [SerializeField] private float flyForce = 5f;

    private void Update()
    {
        if (myControlContainer.flyController)
        {
            myRigidbody2D.AddForce(Vector2.up*flyForce);
        }
    }
}
