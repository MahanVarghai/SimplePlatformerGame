using UnityEngine;

public class EnemyAnimationHandler : MonoBehaviour
{
    private Animator anim;
    public bool Walking { get; set; } = false;
    public bool Dead { get; set; } = false;
    public  bool TakeDamage { get; set; } = false;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        WalkAnimationHandler();
        DeathAnimationHandler();
        TakeDamageAnimationHandler();
    }

    private void WalkAnimationHandler()
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
    private void DeathAnimationHandler()
    {
        if(Dead) 
            anim.SetTrigger(TagManagement.ENEMY_DEATH_ANIMATION_TRIGGER);
        Dead = false;
    }
    private void TakeDamageAnimationHandler()
    {
        if (TakeDamage)
            anim.SetTrigger(TagManagement.ENEMY_TAKE_DAMAGE_ANIMATION_TRIGGER);
        TakeDamage = false;
    }
}
