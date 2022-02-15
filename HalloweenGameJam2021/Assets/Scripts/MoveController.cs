using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField] private CommandContainer myCommandContainer;
    [SerializeField] private Rigidbody2D myRigidBody2D;
    [SerializeField] private float moveSpeed = 5f;
    void Update()
    {
        if (myCommandContainer.moveCommand != 0)
        {
            myRigidBody2D.velocity = new Vector2(moveSpeed * myCommandContainer.moveCommand, myRigidBody2D.velocity.y);
        }    
    }
}
