using UnityEngine;

public abstract class EnemyBaseState
{
    protected bool isRootState = false;
    protected EnemyStateMachine ctx;
    protected EnemyStateFactory factory;
    protected EnemyBaseState currentSuperState;
    protected EnemyBaseState currentSubState;
    public EnemyBaseState(EnemyStateMachine currentContext, EnemyStateFactory enemyStateFactory)
    {
        ctx = currentContext;
        factory = enemyStateFactory;
    }
    public abstract void EnterState();
    public abstract void ExitState();
    public abstract void UpdateState();
    public abstract void CheckSwitchState();
    public abstract void InitializeSubState();
    public virtual void FixedUpdateState() { }
    public void UpdateStates() 
    {
        UpdateState();
        if (currentSubState != null) 
        {
            currentSubState.UpdateStates();
        }
    }
    public void FixedUpdateStates()
    {
        FixedUpdateState();
        if (currentSubState != null)
        {
            currentSubState.FixedUpdateStates();
        }
    }
    protected void SwitchState(EnemyBaseState newState) 
    {
        // current state exits states
        ExitState();

        // new state enters state
        newState.EnterState();

        if (isRootState)
        {
            ctx.currentState = newState;
        }
        else if (currentSuperState != null)
            currentSuperState.SetSubState(newState);

    }
    protected void SetSuperState(EnemyBaseState newSuperState) 
    {
        currentSuperState = newSuperState;
    }
    protected void SetSubState(EnemyBaseState newSubState)
    {
        currentSubState = newSubState;
        newSubState.SetSuperState(this);
    }
}


