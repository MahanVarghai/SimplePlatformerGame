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

        playerLocation = GameObject.FindGameObjectWithTag("Target For Enemeis").transform;
    }

    private void FixedUpdate()
    {
        EnemyWalkHandler();
    }

    private void EnemyWalkHandler()
    {
        if (isRisigAnimationDone)
        {
            if(Vector3.Distance(transform.position, playerLocation.position) > 2.5f)
            {

                rb.linearVelocityX = Vector3.left.x * speed;
                enemyAnimationHandler.Walking = true;
                enemyAnimationHandler.Attacking = false;

            }
            else
            {
                rb.linearVelocityX = 0f;
                enemyAnimationHandler.Walking = false;
                enemyAnimationHandler.Attacking = true;

            }

        }
    }
    public void IsRisingAnimationDone() => isRisigAnimationDone = true;
}
