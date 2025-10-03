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
            GetComponent<Collider2D>().enabled = false;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
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

