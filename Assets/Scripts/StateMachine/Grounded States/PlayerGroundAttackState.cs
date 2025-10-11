using UnityEditor;
using UnityEngine;
public class PlayerGroundAttackState: PlayerBaseState
{
    public PlayerGroundAttackState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
        : base(currentContext, playerStateFactory) { }

    public override void EnterState()
    {
        Debug.Log("Entered Grounded Attack State");
        ctx.animator.Play("PlayerAttack1");
    }
    public override void ExitState()
    {
        Debug.Log("Exited Grounded Attack State");
    }
    public override void UpdateState()
    {
        CheckSwitchState();
    }
    public override void InitializeSubState() { }
    public override void CheckSwitchState()
    {
        if (ctx.animator.GetCurrentAnimatorStateInfo(0).IsName("PlayerAttack1")
            && ctx.animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            SwitchState(factory.Idle());
        }
    }
}

