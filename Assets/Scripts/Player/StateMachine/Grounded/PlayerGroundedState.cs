using UnityEngine;

public class PlayerGroundedState : PlayerBaseState
{
    public PlayerGroundedState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
        : base(currentContext, playerStateFactory)
    {
        InitializeSubState();
        isRootState = true;
    }
    public override void EnterState()
    {
        Debug.Log("Entered Grounded State");
    }
    public override void ExitState()
    {
        Debug.Log("Exited Grounded State");
    }
    public override void UpdateState()
    {
        CheckSwitchState();
    }
    public override void InitializeSubState()
    {
        if (ctx.moveDirection != 0)
        {
            SetSubState(factory.Run());
        }
        else
        {
            SetSubState(factory.Idle());
        }
        SwitchState(currentSubState);
    }
    public override void CheckSwitchState()
    {
        // if player is grounded and jump is pressed switch state
        if (ctx.isJumpPressed)
        {
            SwitchState(factory.Airborne());
        }
    }
}