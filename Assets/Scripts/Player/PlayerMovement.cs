using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float jumpForce = 7f;

    private Rigidbody2D rb;
    private PlayerAnimationHandler paHandler;

    private float moveInput;
    private bool jumpInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        paHandler = GetComponent<PlayerAnimationHandler>();
    }
    private void Update()
    {
        getMoveInput();
        getJumpInput();
        jumpHandler();

        setAnimationHandler();
    }
    private void FixedUpdate()
    {
        moveHandler();
    }
    private void getMoveInput()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
    }
   private void getJumpInput()
    {
        jumpInput = Input.GetButtonDown("Jump") && Mathf.Abs(rb.linearVelocityY) < 0.001f;
    }
    private void setAnimationHandler()
    {
        paHandler.MoveingDirection = (int)moveInput;
        paHandler.VelocityY = rb.linearVelocityY;
    }
    private void moveHandler()
    {
        rb.linearVelocityX = moveInput * speed;
    }
    private void jumpHandler()
    {
        if (jumpInput)
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
    }
}

