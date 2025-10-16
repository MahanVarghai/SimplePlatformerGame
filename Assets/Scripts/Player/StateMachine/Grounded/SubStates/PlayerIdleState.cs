using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public PlayerIdleState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
        : base(currentContext, playerStateFactory) { }
    public override void EnterState()
    {
        Debug.Log("Entered Idle State");
        ctx.animator.Play("PlayerIdle");
        ctx.rb.linearVelocityX = 0f;
    }
    public override void ExitState() { Debug.Log("Exited Idle State"); }
    public override void UpdateState() { CheckSwitchState(); }
    public override void InitializeSubState() { }
    public override void CheckSwitchState()
    {
        if (ctx.moveDirection != 0)
        {
            SwitchState(factory.Run());
        }
        else
        {
            if (ctx.attackingDelay <= 0f && ctx.isAttackPressed)
                SwitchState(factory.GroundedAttack());

            else if(ctx.attackingDelay > 0f)
                ctx.attackingDelay -= Time.deltaTime;

        }

    }
}