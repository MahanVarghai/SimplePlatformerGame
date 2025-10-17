using UnityEngine;
public class PlayerStateMachine : MonoBehaviour
{
    // reference variables
    public Animator animator;
    public Rigidbody2D rb;
    public GameObject damageCollider;
    public float currentHealth = 100;
    public float damageAmounts = 25;
    public float moveSpeed = 5f;
    public float jumpForce = 7.5f;

    // movement variables
    public float moveDirection = 0;

    // jump variables
    public bool isJumpPressed = false;
    public bool isGrounded = false;

    // damage variables
    public bool isAttackPressed = false;
    public float attackingDelay = 0f;

    //state variables
    public PlayerBaseState currentState;
    public PlayerStateFactory states;

    // Awake is called earlier than Start in Unity's event life cycle
    private void Awake()
    {
        // initially set reference variables
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        // setup state
        states = new PlayerStateFactory(this);
        currentState = states.Grounded();
        currentState.EnterState();
    }

    // Update is called once per frame
    private void Update()
    {
        moveDirection = Input.GetAxisRaw("Horizontal");
        isJumpPressed = Input.GetButtonDown("Jump");
        isAttackPressed = Input.GetButtonDown("Fire1");
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







//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.InputSystem;

//public class PlayerStateMachine : MonoBehaviour
//{
//    // declare reference variables
//    CharacterController _characterController;
//    Animator _animator;
//    PlayerInput _playerInput; // NOTE: PlayerInput class must be generated from New Input System in Inspector

//    // variables to store optimized setter/getter parameter IDs
//    int _isWalkingHash;
//    int _isRunningHash;

//    // variables to store player input values
//    Vector2 _currentMovementInput;
//    Vector3 _currentMovement;
//    Vector3 _appliedMovement;
//    bool _isMovementPressed;
//    bool _isRunPressed;

//    // constants
//    float _rotationFactorPerFrame = 15.0f;
//    float _runMultiplier = 4.0f;
//    int _zero = 0;

//    // gravity variables
//    float _gravity = -9.8f;
//    float _groundedGravity = -.05f;

//    // jumping variables
//    bool _isJumpPressed = false;
//    float _initialJumpVelocity;
//    float _maxJumpHeight = 4.0f;
//    float _maxJumpTime = .75f;
//    bool _isJumping = false;
//    int _isJumpingHash;
//    int _jumpCountHash;
//    bool _isJumpAnimating = false;
//    int _jumpCount = 0;
//    Dictionary<int, float> _initialJumpVelocities = new Dictionary<int, float>();
//    Dictionary<int, float> _jumpGravities = new Dictionary<int, float>();
//    Coroutine _currentJumpResetRoutine = null;

//    // state variables
//    PlayerBaseState _currentState;
//    PlayerStateFactory _states;

//    // getter and setter
//    public PlayerBaseState CurrentState { get { return _currentState; } set { _currentState = value; } }
//    public bool IsJumpPressed { get { return _isJumpPressed; } }

//    // Awake is called earlier than Start in Unity's event life cycle
//    void Awake()
//    {

//        // initially set reference variables
//        _playerInput = new PlayerInput();
//        _characterController = GetComponent<CharacterController>();
//        _animator = GetComponent<Animator>();

//        // setup state
//        _states = new PlayerStateFactory(this);
//        _currentState = _states.Grounded();
//        _currentState.EnterState();

//        // set the parameter hash references
//        _isWalkingHash = Animator.StringToHash("isWalking");
//        _isRunningHash = Animator.StringToHash("isRunning");
//        _isJumpingHash = Animator.StringToHash("isJumping");
//        _jumpCountHash = Animator.StringToHash("jumpCount");

//        // set the player input callbacks
//        //_playerInput.CharacterControls.Move.started += OnMovementInput;
//        //_playerInput.CharacterControls.Move.canceled += OnMovementInput;
//        //_playerInput.CharacterControls.Move.performed += OnMovementInput;
//        //_playerInput.CharacterControls.Run.started += OnRun;
//        //_playerInput.CharacterControls.Run.canceled += OnRun;
//        //_playerInput.CharacterControls.Jump.started += OnJump;
//        //_playerInput.CharacterControls.Jump.canceled += OnJump;

//        SetupJumpVariables();
//    }

//    // set the initial velocity and gravity using jump heights and durations
//    void SetupJumpVariables()
//    {

//        float timeToApex = _maxJumpTime / 2;
//        _gravity = (-2 * _maxJumpHeight) / Mathf.Pow(timeToApex, 2);
//        _initialJumpVelocity = (2 * _maxJumpHeight) / timeToApex;
//        float secondJumpGravity = (-2 * (_maxJumpHeight + 2)) / Mathf.Pow((timeToApex * 1.25f), 2);
//        float secondJumpInitialVelocity = (2 * (_maxJumpHeight + 2)) / (timeToApex * 1.25f);
//        float thirdJumpGravity = (-2 * (_maxJumpHeight + 4)) / Mathf.Pow((timeToApex * 1.5f), 2);
//        float thirdJumpInitialVelocity = (2 * (_maxJumpHeight + 4)) / (timeToApex * 1.5f);

//        _initialJumpVelocities.Add(1, _initialJumpVelocity);
//        _initialJumpVelocities.Add(2, secondJumpInitialVelocity);
//        _initialJumpVelocities.Add(3, thirdJumpInitialVelocity);

//        _jumpGravities.Add(0, _gravity);
//        _jumpGravities.Add(1, _gravity);
//        _jumpGravities.Add(2, secondJumpGravity);
//        _jumpGravities.Add(3, thirdJumpGravity);

//    }
//    // Start is called before the first frame update
//    void Start()
//    {

//    }

//    // Update is called once per frame
//    void Update()
//    {
//        _currentState.UpdateState();
//        //HandleRotation();
//        //_characterController.Move(_appliedMovement * Time.deltaTime);
//    }
//    void HandleRotation()
//    {

//        Vector3 positionToLookAt;
//        // the change in position our character should point to
//        positionToLookAt.x = _currentMovementInput.x;
//        positionToLookAt.y = _zero;
//        positionToLookAt.z = _currentMovementInput.y;
//        // the current rotation of our character
//        Quaternion currentRotation = transform.rotation;

//        if (_isMovementPressed)
//        {

//            // creates a new rotation based on where the player is currently pressing
//            Quaternion targetRotation = Quaternion.LookRotation(positionToLookAt);
//            // rotate the character to face the positionToLookAt
//            transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, _rotationFactorPerFrame * Time.deltaTime);
//        }
//    }
//    // callback handler function to set the player input values
//    void OnMovementInput(InputAction.CallbackContext context)
//    {
//        _currentMovementInput = context.ReadValue<Vector2>();
//        _isMovementPressed = _currentMovementInput.x != _zero || _currentMovementInput.y != _zero;
//    }
//    // callback handler function for jump buttons
//    void OnJump(InputAction.CallbackContext context)
//    {
//        _isJumpPressed = context.ReadValueAsButton();
//    }
//    // callback handler function for run buttons
//    void OnRun(InputAction.CallbackContext context)
//    {
//        _isRunPressed = context.ReadValueAsButton();
//    }
//    void OnEnable()
//    {

//        // enable the character controls action map
//        //_playerInput.CharacterControls.Enable();

//    }

//    void OnDisable()
//    {

//        // disable the character controls action map
//        //playerInput.CharacterControls.Disable();

//    }
//}