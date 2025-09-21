using UnityEngine;

public class PlayerAnimationHandler : MonoBehaviour
{
    private Animator anim;
    private SpriteRenderer sr;

    public bool IsGrounded { get; set; }
    public int MoveingDirection { get; set; }
    public float VelocityY { get; set; }
    public bool Attacking1 { get; set; }

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
        void Update()
    {
        RunAnimationHandler();
        JumpAndFallAnimtionHandler();
        AttackAnimationHandler();
    }
    private void RunAnimationHandler()
    {
        if (MoveingDirection != 0)
        {
            anim.SetBool(TagManagement.PLAYET_RUN_ANIMTION_BOOL, true);
            anim.SetBool(TagManagement.PLAYER_IDLE_ANIMATION_BOOL, false);
            if (MoveingDirection < 0)
                transform.localScale = new Vector3(Vector3.left.x ,transform.localScale.y , transform.localScale.z);
            else if (MoveingDirection > 0)
                transform.localScale = new Vector3(Vector3.right.x, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            anim.SetBool(TagManagement.PLAYET_RUN_ANIMTION_BOOL, false);
            anim.SetBool(TagManagement.PLAYER_IDLE_ANIMATION_BOOL, true);
        }

    }
    private void JumpAndFallAnimtionHandler()
    {
        if (VelocityY == 0)
        {
            anim.SetBool(TagManagement.PLAYER_JUMP_ANIMATION_BOOL, false);
            anim.SetBool(TagManagement.PLAYER_FALL_ANIMATION_BOOL, false);
        }
        else
        {
            if (VelocityY < 0)
            {
                anim.SetBool(TagManagement.PLAYER_FALL_ANIMATION_BOOL, true);
                anim.SetBool(TagManagement.PLAYER_JUMP_ANIMATION_BOOL, false);
            }
            else
            {
                anim.SetBool(TagManagement.PLAYER_JUMP_ANIMATION_BOOL, true);
                anim.SetBool(TagManagement.PLAYER_FALL_ANIMATION_BOOL, false);
            }
            anim.SetBool(TagManagement.PLAYER_IDLE_ANIMATION_BOOL, false);
            anim.SetBool(TagManagement.PLAYET_RUN_ANIMTION_BOOL, false);
        }
        
    }

    private void AttackAnimationHandler()
    {
        if (Attacking1)
        {
            anim.SetTrigger(TagManagement.PLAYER_ATTACK1_ANIMATUION_TRIGGER);
            Attacking1 = false;
        }
    }
}
