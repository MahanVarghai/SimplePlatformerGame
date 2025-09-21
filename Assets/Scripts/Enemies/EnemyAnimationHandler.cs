using UnityEngine;

public class EnemyAnimationHandler : MonoBehaviour
{
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void WalkAnimationHandler()
    {
        anim.SetBool(TagManagement.ENEMY_WALK_ANIMATION_BOOL, true);
    }
}
