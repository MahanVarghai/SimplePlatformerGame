using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField]
    private int damageAmount = 10;
    [SerializeField]
    private bool isPlayerWhoAttack = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isPlayerWhoAttack && collision.CompareTag(TagManagement.ENEMY_TAG))
            collision.GetComponent<Health>().TakeDamage(damageAmount);

        else if (!isPlayerWhoAttack && collision.CompareTag(TagManagement.PLAYER_TAG))
            collision.GetComponent<Health>().TakeDamage(damageAmount);
    }
}
