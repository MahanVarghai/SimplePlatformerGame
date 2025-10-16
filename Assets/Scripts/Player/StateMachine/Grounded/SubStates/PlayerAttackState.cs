using UnityEngine;
public class PlayerAttackState : PlayerBaseState
{
    private bool isComboSuccessful = false;
    private int attackCounter = 1;
    public PlayerAttackState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
        : base(currentContext, playerStateFactory) { }

    public override void EnterState()
    {
        Debug.Log("Entered Grounded Attack State");
        ctx.rb.linearVelocityY = 0;
        ctx.animator.Play("PlayerAttack1");
    }
    public override void ExitState() { Debug.Log("Exited Grounded Attack State"); }
    public override void UpdateState() { CheckSwitchState(); }
    public override void InitializeSubState() { }
    public override void CheckSwitchState()
    {
        // check for end of animation
        AnimatorStateInfo stateInfo = ctx.animator.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.normalizedTime > 0.05f && stateInfo.normalizedTime < 0.95f
            && !isComboSuccessful && ctx.isAttackPressed)
        {
            isComboSuccessful = true;
            attackCounter++;
            attackCounter = attackCounter == 4 ? 1 : attackCounter;
        }
        else if (stateInfo.normalizedTime >= 1f)
        {
            if (!isComboSuccessful)
            {
                ctx.attackingDelay = 0.13f; // small delay to prevent immediate re-attack
                SwitchState(factory.Idle());
            }
            else
            {
                switch (attackCounter)
                {
                    case 1: 
                        ctx.animator.Play("PlayerAttack1"); break;
                    case 2:
                        ctx.animator.Play("PlayerAttack2"); break;
                    case 3: 
                        ctx.animator.Play("PlayerAttack3"); break;
                }
                isComboSuccessful = false;
            }

        }
    }
}



