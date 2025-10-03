using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField]
    private int damageAmount = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (transform.parent.CompareTag(TagManagement.PLAYER_TAG) && collision.CompareTag(TagManagement.ENEMY_TAG))
            collision.GetComponent<EnemyHealth>().TakeDamage(damageAmount);

        else if (transform.parent.CompareTag(TagManagement.ENEMY_TAG) && collision.CompareTag(TagManagement.PLAYER_TAG))
            collision.GetComponent<PlayerHealth>().TakeDamage(damageAmount);
    }
}
