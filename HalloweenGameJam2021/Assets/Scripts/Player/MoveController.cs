using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField] private Animator myAnimator;
    [SerializeField] private SpriteRenderer mySpriteRenderer;
    [SerializeField] private CommandContainer myCommandContainer;
    [SerializeField] private Rigidbody2D myRigidBody2D;
    public float moveSpeed = 5f;
    [SerializeField] private float animationCounter;
    [SerializeField] private float animationTime = 0.1f;
    [SerializeField] private bool lastInput;

    private void Start()
    {
        lastInput = true;
    }

    void Update()
    {
        //turnAnim();
        if (myCommandContainer.moveCommand != 0)
        {
            myRigidBody2D.velocity = new Vector2(moveSpeed * myCommandContainer.moveCommand, myRigidBody2D.velocity.y);
        }

        if (myCommandContainer.moveCommand > 0)
        {
            mySpriteRenderer.flipX = true;
        }

        if (myCommandContainer.moveCommand < 0)
        {
            mySpriteRenderer.flipX = false;
        }
    }

    void turnAnim()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                lastInput = true;
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                lastInput = false;
            }

            if (!lastInput)
            {
                if (Input.GetKeyDown(KeyCode.A))
                {
                    Debug.Log("turn");
                }
                myAnimator.SetTrigger("Turning");
                animationCounter -= Time.deltaTime;
                if (animationCounter < 0)
                {
                    animationCounter = animationTime;
                    myAnimator.SetTrigger("StoppedTurning");
                }
            }
            if (myCommandContainer.moveCommand > 0 && lastInput)
            {
                Debug.Log("turn");
                myAnimator.SetTrigger("Turning");
                animationCounter -= Time.deltaTime;
                if (animationCounter < 0)
                {
                    animationCounter = animationTime;
                    myAnimator.SetTrigger("StoppedTurning");
                }
            }
        }
    }
}
