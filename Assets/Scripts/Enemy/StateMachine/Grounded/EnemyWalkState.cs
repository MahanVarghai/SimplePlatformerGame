using UnityEngine;

public class EnemyWalkState : EnemyBaseState
{
    public EnemyWalkState(EnemyStateMachine currentContext, EnemyStateFactory enemyStateFactory)
        : base(currentContext, enemyStateFactory)
    {
        InitializeSubState();
    }
    public override void EnterState()
    {
        ctx.animator.Play("SkeletonWalk");
    }
    public override void ExitState()
    { 
    }
    public override void UpdateState()
    {
        ctx.rb.linearVelocityX = -1 * ctx.moveSpeed;
        CheckSwitchState();
    }
    public override void InitializeSubState()
    {
        
        
        //SwitchState(currentSubState);
    }
    public override void CheckSwitchState()
    {
        if (Vector3.Distance(ctx.transform.position, ctx.Target.position) <= 2.5f)
            SwitchState(factory.Attack());
    }
}