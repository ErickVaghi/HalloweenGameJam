using UnityEngine;

public class DashController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D myRigidBody2D;
    [SerializeField] private CommandContainer commandContainer;
    [SerializeField] private InputController myInputController;
    [SerializeField] private MoveController myMoveController;
    
    public float dashMoltiplier = 3f;
    
    [SerializeField] private float dashTime = 5f;
    [SerializeField] private float dashTimeCounter = 0f;
    [SerializeField] private bool isDashing;
    
    public float verticalVelocityMultiplier = 1f; 

    private float originalSpeed;
    private float tempWalkSpeed; 

    private void Start()
    {
        isDashing = false;
        originalSpeed = myMoveController.moveSpeed;
    }

    private void Update()
    {
        HandleDash();
    }

    void HandleDash()
    {
        if (commandContainer.dashCommand && !isDashing)
        {
            tempWalkSpeed = myMoveController.moveSpeed * dashMoltiplier;
            myMoveController.moveSpeed = tempWalkSpeed;
            verticalVelocityMultiplier = 0;
            dashTimeCounter = dashTime;
            myInputController.enabled = false;
            commandContainer.dashCommand = false;
            isDashing = true;
        }
        if (isDashing)
        {
            dashTimeCounter -= Time.deltaTime;
            if (dashTimeCounter <= 0)
            {
                myInputController.enabled = true;
                verticalVelocityMultiplier = 1;
                myMoveController.moveSpeed = originalSpeed;
                isDashing = false;
            }
        }
    }
    // void HandleDash()
    // {
    //     if (commandContainer.dashCommand && !isDashing)
    //     {
    //         tempWalkSpeed = myMoveController.moveSpeed * dashMoltiplier;
    //         myMoveController.moveSpeed = tempWalkSpeed;
    //         verticalVelocityMultiplier = 0;
    //         dashTimeCounter = dashTime;
    //         myInputController.enabled = false;
    //         commandContainer.dashCommand = false;
    //         isDashing = true;
    //     }
    //     if (isDashing)
    //     {
    //         dashTimeCounter -= Time.deltaTime;
    //         if (dashTimeCounter <= 0)
    //         {
    //             myInputController.enabled = true;
    //             verticalVelocityMultiplier = 1;
    //             myMoveController.moveSpeed = originalSpeed;
    //             isDashing = false;
    //         }
    //     }
    // }
}
