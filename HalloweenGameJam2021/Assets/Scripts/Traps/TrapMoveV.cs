using UnityEngine;

public class TrapMoveV : MonoBehaviour
{
    [SerializeField] private Transform pos1;
    [SerializeField] private Transform pos2;

    [SerializeField] private float speed = 5f;

    private bool turnBack;
    void Update()
    {
        HandleTrapMovement();
    }

    void HandleTrapMovement()
    {
        if (transform.position.y >= pos1.position.y)
        {
            turnBack = true;
            Debug.Log(" turn back true");
        }
        if (transform.position.y <= pos2.position.y)
        {
            turnBack = false;
            Debug.Log(" turn back false");
        }

        if (turnBack)
        {
            transform.position = Vector2.MoveTowards(transform.position, pos2.position, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, pos1.position, speed * Time.deltaTime);
        }
    }
}
