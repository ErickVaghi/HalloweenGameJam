using UnityEngine;

public class TrapMoveH : MonoBehaviour
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
        if (transform.position.x >= pos1.position.x)
        {
            turnBack = true;
        }
        if (transform.position.x <= pos2.position.x)
        {
            turnBack = false;
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
