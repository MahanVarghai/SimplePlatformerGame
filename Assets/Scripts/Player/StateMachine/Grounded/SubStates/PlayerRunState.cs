using UnityEngine;

public class PlayerRunState : PlayerBaseState
{
    public PlayerRunState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
        : base(currentContext, playerStateFactory) { }
    public override void EnterState() 
    {
        Debug.Log("Entered Run State");
        ctx.animator.Play("PlayerRun");
    }
    public override void ExitState() 
    {
        Debug.Log("Exited Run State");
    }
    public override void UpdateState() 
    {
        CheckSwitchState();
    }
    public override void InitializeSubState() { }
    public override void CheckSwitchState()
    {
        if(ctx.moveDirection == 0)
        {
            SwitchState(factory.Idle());
        }   
    }
    public override void FixedUpdateState()
    {
        ctx.rb.linearVelocityX = ctx.moveDirection * ctx.moveSpeed;
        if (ctx.moveDirection != 0)
            ctx.transform.localScale = new Vector3(ctx.moveDirection * Mathf.Abs(ctx.transform.localScale.x), ctx.transform.localScale.y, ctx.transform.localScale.z);

    }

}