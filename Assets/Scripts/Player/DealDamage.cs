using UnityEngine;

public class DealDamage : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(TagManagement.ENEMY_TAG))
        {
            Debug.Log("Enemy Hit");
            collision.GetComponent<EnemyHealth>().TakeDamage();
        }
    }
}
