using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    private Transform playerLocation;
    private Rigidbody2D rb;
    private EnemyAnimationHandler enemyAnimationHandler;
    private bool isRisigAnimationDone = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyAnimationHandler = GetComponent<EnemyAnimationHandler>();

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
            if(Vector3.Distance(transform.position, playerLocation.position) > 3f)
            {

                rb.linearVelocityX = Vector3.left.x * speed;
                enemyAnimationHandler.Walking = true;

            }
            else
            {
                rb.linearVelocityX = 0f;
                enemyAnimationHandler.Walking = false;

            }

        }
    }
    public void IsRisingAnimationDone() => isRisigAnimationDone = true;
}
