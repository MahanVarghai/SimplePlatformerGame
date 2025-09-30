using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int health = 100;

    private AnimationHandler animationHandler;
    private void Start()
    {
        if(gameObject.CompareTag(TagManagement.PLAYER_TAG))
            animationHandler = GetComponent<PlayerAnimationHandler>();
        else if(gameObject.CompareTag(TagManagement.ENEMY_TAG))
            animationHandler = GetComponent<EnemyAnimationHandler>();

    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            animationHandler.Dead = true;
            return;
        }
        else
        {
            animationHandler.TakeDamage = true;
        }
    }
    public void EnemyDeath()
    {
        Destroy(gameObject);
    }
}

