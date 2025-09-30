using UnityEngine;

public class EnemyAnimationHandler : AnimationHandler
{
    public bool Attacking { get; set; } = false;

    private void Update()
    {
        WalkAnimationHandler();
        DeathAnimationHandler();
        AttackAnimationHandler();
        TakeDamageAnimationHandler();
    }

    protected override void WalkAnimationHandler()
    {
        if (Walking)
        {
            anim.SetBool(TagManagement.ENEMY_WALK_ANIMATION_BOOL, true);
            anim.SetBool(TagManagement.ENEMY_IDLE_ANIMATION_BOOL, false);
        }
        else
        {
            anim.SetBool(TagManagement.ENEMY_WALK_ANIMATION_BOOL, false);
            anim.SetBool(TagManagement.ENEMY_IDLE_ANIMATION_BOOL, true);
        }
    }
    protected override void DeathAnimationHandler()
    {
        if(Dead) 
            anim.SetTrigger(TagManagement.ENEMY_DEATH_ANIMATION_TRIGGER);
        Dead = false;
    }
    protected override void AttackAnimationHandler()
    {
        anim.SetBool(TagManagement.ENEMY_ATTACK_ANIMATION_BOOL, Attacking);      
    }
    protected override void TakeDamageAnimationHandler()
    {
        if (TakeDamage)
            anim.SetTrigger(TagManagement.ENEMY_TAKE_DAMAGE_ANIMATION_TRIGGER);
        TakeDamage = false;
    }
}
