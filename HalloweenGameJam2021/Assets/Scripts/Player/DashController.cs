using UnityEngine;

public class DashController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D myRigidBody2D;
    [SerializeField] private CommandContainer commandContainer;
    [SerializeField] private InputController myInputController;
    [SerializeField] private MoveController myMoveController;
    //[SerializeField] private Collider2D myCollider;
    [SerializeField] private Animator myAnimator;

    public float dashMoltiplier = 3f;

    [SerializeField] private float shakeIntensity = 2f;
    
    [SerializeField] private float dashTime = 5f;
    [SerializeField] private float dashTimeCounter = 0f;
    public static bool isDashing;
    
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
        if (commandContainer.dashCommand && !isDashing && (myRigidBody2D.velocity.x < -0.5f || myRigidBody2D.velocity.x > 0.5f))
        {
            CameraShake.Instance.ShakeCamera(shakeIntensity, dashTime);
            
            tempWalkSpeed = myMoveController.moveSpeed * dashMoltiplier;
            myMoveController.moveSpeed = tempWalkSpeed;
            verticalVelocityMultiplier = 0;
            dashTimeCounter = dashTime;
            myInputController.enabled = false;
            //myCollider.enabled = false;
            commandContainer.dashCommand = false;
            isDashing = true;
            myAnimator.SetTrigger("Dashing");
        }
        if (isDashing)
        {
            dashTimeCounter -= Time.deltaTime;
            if (dashTimeCounter <= 0)
            {
                myAnimator.ResetTrigger("Dashing");
                myInputController.enabled = true;
                //myCollider.enabled = true;
                verticalVelocityMultiplier = 1;
                myMoveController.moveSpeed = originalSpeed;
                isDashing = false;
            }
        }
    }
}
