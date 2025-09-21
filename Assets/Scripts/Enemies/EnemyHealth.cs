using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public void TakeDamage()
    {
        Debug.Log("Enemy Hit - Destroyed");
        Destroy(gameObject);
    }
}

