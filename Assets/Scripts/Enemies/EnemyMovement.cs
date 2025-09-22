using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    private Transform playerLocation;
    private Rigidbody2D rb;
    private EnemyAnimationHandler eHandler;
    private bool isRisigAnimationDone = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerLocation = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        EnemyWalkHandler();
    }

    private void EnemyWalkHandler()
    {
        if (isRisigAnimationDone)
        {
            if(Vector3.Distance(transform.position, playerLocation.position) > 0.5f)
            {
                rb.linearVelocityX = Vector3.left.x * speed; return;
                eHandler.IdleAnimation = false;
            }
            else
            {
                rb.linearVelocityX = 0f;
                eHandler.IdleAnimation = true;
            }

        }
    }
    public void IsRisingAnimationDone() => isRisigAnimationDone = true;
}
