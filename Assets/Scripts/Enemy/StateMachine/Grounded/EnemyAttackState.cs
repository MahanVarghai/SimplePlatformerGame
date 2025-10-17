using UnityEngine;

public class EnemyAttackState : EnemyBaseState
{
    private bool attackThreshold = false;
    public EnemyAttackState(EnemyStateMachine currentContext, EnemyStateFactory enemyStateFactory)
        : base(currentContext, enemyStateFactory)
    {
        InitializeSubState();
    }
    public override void EnterState()
    {
        Debug.Log("EnemyEntered Grounded Attack State");
        ctx.animator.Play("SkeletonAttack");
        ctx.rb.linearVelocityX = 0;
    }
    public override void ExitState() { }
    public override void UpdateState()
    {
        if(ctx.animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.5f && !attackThreshold)
        {
            ctx.damageCollider.SetActive(true);
            attackThreshold = true;
        }
        CheckSwitchState();
    }
    public override void InitializeSubState() { }
    public override void CheckSwitchState()
    {
        if (ctx.animator.GetCurrentAnimatorStateInfo(0).IsName("SkeletonAttack") &&
            ctx.animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            if (Vector3.Distance(ctx.transform.position, ctx.Target.position) <= 2.5f)
            {
                ctx.animator.Play("SkeletonAttack");
                attackThreshold = false;
            }
            else
                SwitchState(factory.Walk());
        }

    }
}