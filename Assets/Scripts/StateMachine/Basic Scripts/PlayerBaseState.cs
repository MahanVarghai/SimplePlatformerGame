using UnityEngine;

public abstract class PlayerBaseState
{
    protected bool isRootState = false;
    protected PlayerStateMachine ctx;
    protected PlayerStateFactory factory;
    protected PlayerBaseState currentSuperState;
    protected PlayerBaseState currentSubState;
    public PlayerBaseState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
    {
        ctx = currentContext;
        factory = playerStateFactory;
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
    protected void SwitchState(PlayerBaseState newState) 
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
    protected void SetSuperState(PlayerBaseState newSuperState) 
    {
        currentSuperState = newSuperState;
    }
    protected void SetSubState(PlayerBaseState newSubState)
    {
        currentSubState = newSubState;
        newSubState.SetSuperState(this);
    }
}


