using UnityEngine;

public class EnemyAnimationHandler : MonoBehaviour
{
    private Animator anim;
    public bool IdleAnimation { get; set; } = false;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        IdleAnimationHandler();
    }
    public void WalkAnimationHandler()
    {
        anim.SetBool(TagManagement.ENEMY_WALK_ANIMATION_BOOL, true);
    }
    public void IdleAnimationHandler()
    {
        if (IdleAnimation)
        {
            anim.SetBool(TagManagement.ENEMY_WALK_ANIMATION_BOOL, false);
            anim.SetBool(TagManagement.ENEMY_IDLE_ANIMATION_BOOL, true);
        }
        else
        {
            anim.SetBool(TagManagement.ENEMY_IDLE_ANIMATION_BOOL, false);
            anim.SetBool(TagManagement.ENEMY_IDLE_ANIMATION_BOOL, true);
        }
    }
}
