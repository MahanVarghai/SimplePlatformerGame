using UnityEngine;

public class EnemyPatrolState : EnemyBaseState
{
    public EnemyPatrolState(EnemyStateMachine currentContext, EnemyStateFactory enemyStateFactory)
        : base(currentContext, enemyStateFactory)
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

        SetSubState(factory.Walk());
        SwitchState(currentSubState);
    }
    public override void CheckSwitchState()
    {
        //if (Vector3.Distance(ctx.transform.position, ctx.Target.position) <= 2.5f)
        //    SwitchState(factory.Attack());
        //else 
        //    SwitchState(factory.Walk());

    }
}