using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float jumpForce = 7f;

    private Rigidbody2D rb;
    private PlayerAnimationHandler playerAnimationHandler;

    private float moveInput;
    private bool jumpInput;
    private bool attackInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimationHandler = GetComponent<PlayerAnimationHandler>();
    }
    private void Update()
    {
        GetMoveInput();
        GetJumpInput();
        GetAttackInput();
        JumpHandler();
        AttackHandler();
        SetAnimationHandler();
    }
    private void FixedUpdate()
    {
        MoveHandler();
    }
    private void GetMoveInput()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
    }
   private void GetJumpInput()
    {
        jumpInput = Input.GetButtonDown("Jump") && Mathf.Abs(rb.linearVelocityY) < 0.001f;
    }
    private void GetAttackInput()
    {
        attackInput = Input.GetButtonDown("Fire1");
    }
    private void SetAnimationHandler()
    {
        playerAnimationHandler.MoveingDirection = (int)moveInput;
        playerAnimationHandler.VelocityY = rb.linearVelocityY;
        playerAnimationHandler.Attacking1 = attackInput;
    }
    private void MoveHandler()
    {
        rb.linearVelocityX = moveInput * speed;
    }
    private void JumpHandler()
    {
        if (jumpInput)
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
    }
    private void AttackHandler()
    {
        if (attackInput)
        {
            Debug.Log("don't forget to commplit the attckHandler");
        }
    }
}

