using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private int health = 100;

    private EnemyAnimationHandler enemyAnimationHandler;
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
            return;
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

