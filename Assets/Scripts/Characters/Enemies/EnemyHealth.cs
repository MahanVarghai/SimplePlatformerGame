using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    protected int health = 100;

    private AnimationHandler enemyAnimationHandler;
    private void Start()
    {
       enemyAnimationHandler = GetComponent<EnemyAnimationHandler>();

    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            enemyAnimationHandler.Dead = true;
        }
        else
        {
            enemyAnimationHandler.TakeDamage = true;
        }
    }
    public void EnemyDeath()
    {
        Destroy(gameObject);
    }
}

