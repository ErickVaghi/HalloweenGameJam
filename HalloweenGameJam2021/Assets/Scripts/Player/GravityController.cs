using UnityEngine;

public class GravityController : MonoBehaviour
{
    [SerializeField] private float fallMultiplier = 2.5f;
    [SerializeField] private float lowJumpMultiplier = 2f;
    
    [SerializeField] private Rigidbody2D myRigidbody;
    [SerializeField] private CommandContainer myControlContainer;
    void Update()
    {
        ImprovedFly();
    }
    void ImprovedFly()
    {
        if (myRigidbody.velocity.y < 0)
        {
            myRigidbody.velocity += Vector2.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (myRigidbody.velocity.y > 0 && !myControlContainer.flyCommand)
        {
            myRigidbody.velocity += Vector2.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }
}