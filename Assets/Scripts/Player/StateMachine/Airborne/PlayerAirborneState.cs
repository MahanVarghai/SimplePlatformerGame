using UnityEngine;

public class PlayerAirborneState : PlayerBaseState
{
    public PlayerAirborneState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
        : base(currentContext, playerStateFactory) 
    { 
        InitializeSubState();
        isRootState = true;
    }
    public override void EnterState() 
    {
        Debug.Log("Entered Airborne State");
        ctx.isGrounded = false;
    }
    public override void ExitState() 
    {
        Debug.Log("Exited Airborne State");
    }
    public override void UpdateState() 
    {
        CheckSwitchState();
    }
    public override void InitializeSubState() 
    {
        if(ctx.isJumpPressed || ctx.rb.linearVelocityY > 0) 
            SetSubState(factory.Jump());
        else if(ctx.rb.linearVelocityY < 0)
            SetSubState(factory.Fall());
        SwitchState(currentSubState);
    }
    public override void CheckSwitchState()
    {
        if(ctx.isGrounded)
        {
            SwitchState(factory.Grounded());
        }
    }
    public override void FixedUpdateState()
    {
        ctx.rb.linearVelocityX = ctx.moveDirection * ctx.moveSpeed;
        if (ctx.moveDirection != 0)
            ctx.transform.localScale = new Vector3(ctx.moveDirection * Mathf.Abs(ctx.transform.localScale.x), ctx.transform.localScale.y, ctx.transform.localScale.z);
    }
}