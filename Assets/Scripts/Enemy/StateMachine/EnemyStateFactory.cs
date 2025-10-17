using System;

public class EnemyStateFactory
{
    EnemyStateMachine _context;
    public EnemyStateFactory(EnemyStateMachine currentContext)
    {
        _context = currentContext;
    }

    public EnemyBaseState Grounded()
    { 
        return new EnemyPatrolState(_context, this);
    }

    public EnemyBaseState Walk()
    {
        return new EnemyWalkState(_context, this);
    }

    internal EnemyBaseState Attack()
    {
        return new EnemyAttackState(_context, this);
    }
}