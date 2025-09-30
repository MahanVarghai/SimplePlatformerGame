using UnityEngine;

public abstract class AnimationHandler: MonoBehaviour
{
    public bool Walking { get; set; } = false;
    public bool Dead { get; set; } = false;
    public bool TakeDamage { get; set; } = false;

    protected Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    protected virtual void RunAnimationHandler(){ }
    protected virtual void WalkAnimationHandler() { }
    protected virtual void AttackAnimationHandler() { }
    protected virtual void TakeDamageAnimationHandler() { }
    protected virtual void DeathAnimationHandler(){ }
}