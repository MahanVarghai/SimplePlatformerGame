using UnityEngine;

public class DealDamage : MonoBehaviour
{
    [SerializeField]
    private int damageAmount = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(TagManagement.ENEMY_TAG))
        {
            collision.GetComponent<EnemyHealth>().TakeDamage(damageAmount);
        }
    }
}
