using UnityEngine;

public class PlayerWalkState : PlayerBaseState
{
    public PlayerWalkState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
        : base(currentContext, playerStateFactory) { }
    public override void EnterState()
    {
        Debug.Log("Entered Walk State");
    }
    public override void ExitState()
    {
        Debug.Log("Exited Walk State");
    }
    public override void UpdateState()
    {
        CheckSwitchState();
    }
    public override void InitializeSubState() { }
    public override void CheckSwitchState()
    {

    }

}