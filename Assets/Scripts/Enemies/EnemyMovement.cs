using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;

    private Rigidbody2D rb;
    private bool isRisigAnimationDone = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    private void FixedUpdate()
    {
        EnemyWalkHandler();
    }

    private void EnemyWalkHandler()
    {
        if (isRisigAnimationDone)
            rb.linearVelocityX = Vector3.left.x * speed;
    }
    public void IsRisingAnimationDone() => isRisigAnimationDone = true;
}
