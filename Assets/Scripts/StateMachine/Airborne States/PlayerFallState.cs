using UnityEngine;

internal class PlayerFallState : PlayerBaseState
{
    public PlayerFallState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
        : base(currentContext, playerStateFactory)
    {
        InitializeSubState();
    }

    public override void EnterState()
    {
        Debug.Log("Entered Fall State");
        ctx.isGrouped = false;
        ctx.animator.Play("PlayerFall");
    }
    public override void ExitState()
    {
        Debug.Log("Exited Fall State");
    }
    public override void UpdateState()
    {
        CheckSwitchState();
    }
    public override void InitializeSubState() { }

    public override void CheckSwitchState()
    {
        //if (ctx.rb.linearVelocityY )
        //{
        //    SwitchState(factory.Grounded());
        //}
    }
    public override void FixedUpdateState()
    {
        ctx.rb.linearVelocityX = ctx.moveDirection * ctx.moveSpeed;
        if (ctx.moveDirection != 0)
            ctx.transform.localScale = new Vector3(ctx.moveDirection * Mathf.Abs(ctx.transform.localScale.x), ctx.transform.localScale.y, ctx.transform.localScale.z);
    }

}

    
