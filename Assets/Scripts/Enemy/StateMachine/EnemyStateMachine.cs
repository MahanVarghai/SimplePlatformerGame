using UnityEngine;
public class EnemyStateMachine : MonoBehaviour
{
    // reference variables
    public Animator animator;
    public Rigidbody2D rb;
    public Transform Target;
    public GameObject damageCollider;
    public float currentHealth = 100;
    public float damageAmounts = 25;
    public float moveSpeed = 5f;
    public float jumpForce = 7.5f;

    // movement variables
    public float moveDirection = 0;

    // jump variables
    public bool isGrounded = false;

    // damage variables
    public bool isAttackPressed = false;

    //state variables
    public EnemyBaseState currentState;
    public EnemyStateFactory states;


    // Awake is called earlier than Start in Unity's event life cycle
    private void Awake()
    {
        // initially set reference variables
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();


        // setup state
        states = new EnemyStateFactory(this);
        currentState = states.Grounded();
        currentState.EnterState();
    }

    // Update is called once per frame
    private void Update()
    {
        currentState.UpdateStates();
    }
    private void FixedUpdate()
    {
        currentState.FixedUpdateStates();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}

