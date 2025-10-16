using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    public PlayerJumpState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
        : base(currentContext, playerStateFactory) 
    { 
        InitializeSubState();
    }
    public override void EnterState() 
    {
        Debug.Log("Entered Jump State");
        ctx.isGrounded = false;
        ctx.animator.Play("PlayerJump");
        ctx.rb.AddForce(new Vector2(0, ctx.jumpForce), ForceMode2D.Impulse);
    }
    public override void ExitState() 
    {
        Debug.Log("Exited Jump State");
    }
    public override void UpdateState() 
    {
        CheckSwitchState();
    }
    public override void InitializeSubState() { }
    public override void CheckSwitchState()
    {
        if (ctx.rb.linearVelocityY < 0)
            SwitchState(factory.Fall());
    }
    public override void FixedUpdateState()
    {
        ctx.rb.linearVelocityX = ctx.moveDirection * ctx.moveSpeed;
        if (ctx.moveDirection != 0)
            ctx.transform.localScale = new Vector3(ctx.moveDirection * Mathf.Abs(ctx.transform.localScale.x), ctx.transform.localScale.y, ctx.transform.localScale.z);
    }
}