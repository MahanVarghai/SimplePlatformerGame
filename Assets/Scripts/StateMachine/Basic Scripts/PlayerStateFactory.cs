using System;

public class PlayerStateFactory
{
    PlayerStateMachine _context;
    public PlayerStateFactory(PlayerStateMachine currentContext)
    {
        _context = currentContext;
    }

    public PlayerBaseState Grounded()
    { 
        return new PlayerGroundedState(_context, this);
    }
    public PlayerBaseState Airborne()
    {
        return new PlayerAirborneState(_context, this);
    }
    public PlayerBaseState Idle()
    {
        return new PlayerIdleState(_context, this);
    }
    public PlayerBaseState Walk()
    {
        return new PlayerWalkState(_context, this);
    }
    public PlayerBaseState Run()
    {
        return new PlayerRunState(_context, this);
    }
    public PlayerBaseState Jump()
    {
        return new PlayerJumpState(_context, this);
    }

    internal PlayerBaseState Fall()
    {
        return new PlayerFallState(_context, this);
    }

    internal PlayerBaseState GroundedAttack()
    {
        return new PlayerGroundAttackState(_context, this);
    }
}