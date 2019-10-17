using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class playerController : MonoBehaviour
{
    GameObject objCanvas;

    Player player;

    public AnimationCurve accelerationCurve;
    public AnimationCurve decelerationCurve;

    // Movement curve for the horizontal axis
    AnimationCurve currentHCurve;

    // Movement curve for the vertical axis
    AnimationCurve currentVCurve;

    // How fast the player moves left or right
    float translateSpeed = 4.8f; //4.3

    // Reference to the player ghost rigidbody
    Rigidbody2D rb;

    // Track if player is facing to the left
    bool isFlipped = false;

    // is the game currently paused?
    bool isPaused = false;

    float moveHorizontal;

    // We'll save this so that we can use it to respawn
    Vector2 startPosition;

    // Reference to animtor component attached to this gameobject
    Animator animator;

    // Are we currently in the process of firing?
    bool firing = false;

    [SerializeField]
    GameObject energyBurst; // prefab for the energy burst projectile

    bool shootButton;
    bool jumpButton;
    bool moveLeftButton;
    bool moveRightButton;
    bool moveLeftButtonUp;
    bool moveRightButtonUp;

    // Gameover UI for when the player falls from a platform
    [SerializeField]
    GameObject objFailed;

    // The amount of force applied to projectiles
    float projectileForce = 8f;

    float cooldownBetweenProjectiles = .1f;

    SpriteRenderer sr;

    // Is the player using a gamepad?
    bool gamepadMode;

    enum MoveStates
    {
        IDLE,
        JUMPING,
        FALLING
    }

    bool isGrounded = true;

    MoveStates moveState = MoveStates.IDLE;

    AvailablePortals availablePortals;

    public UnityEvent damageTaken = new UnityEvent();

    private void Awake()
    {
        player = new Player();

        // Listen for shooting
        player.Gameplay.Shoot.started += ctx => shootButton = true;
        player.Gameplay.ReleaseShoot.performed += ctx => shootButton = false;

        // Listen for jumping
        player.Gameplay.Jump.started += ctx => jumpButton = true;
        player.Gameplay.ReleaseJump.performed += ctx => jumpButton = false;

        player.Gameplay.MoveLeft.started += ctx => moveLeftButton = true;
        player.Gameplay.ReleaseLeft.performed += ctx => moveLeftButton = false;

        player.Gameplay.MoveRight.started += ctx => moveRightButton = true;
        player.Gameplay.ReleaseRight.performed += ctx => moveRightButton = false;

    }

    public void OnEnable()
    {
        player.Gameplay.Enable();
    }

    public void OnDisable()
    {
        player.Gameplay.Disable();
    }


    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();

        // Adds this script as a listener for the event when the player falls from a platform
        ghostCatcher.AddFallenGhostListener(FallenGhostHandler);

        // Adds this script as a listener for the game paused event
        GameManager.AddGamePausedEventListener(GamePausedHandler);

        // Initialize start position
        startPosition = transform.position;

        // Initialize current horizontal Curve to acceleration. 
        currentHCurve = accelerationCurve;

        // Initialize current vertical Curve to acceleration
        currentVCurve = accelerationCurve;

        rb = gameObject.GetComponent<Rigidbody2D>();

        sr = GetComponentInChildren<SpriteRenderer>();

        availablePortals = GameObject.FindGameObjectWithTag("availablePortals").GetComponent<AvailablePortals>();

        gamepadMode = CheckGamepadState();
        //gamepadMode = false;

        InputSystem.onDeviceChange += DeviceChange;
    }

    void DeviceChange(InputDevice device, InputDeviceChange change)
    {
        gamepadMode = CheckGamepadState();
    }

    // Handles collisions with platforms
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "platform" && moveState == MoveStates.JUMPING)
        {
            moveState = MoveStates.FALLING;
        }

        if (!isGrounded)
        {
            isGrounded = true;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "pacman")
        {
            CollidedWithPacman();
        }
    }

    // Handles the pausing of the play in response to game paused event
    void GamePausedHandler()
    {
        isPaused = !isPaused;
    }

    void CollidedWithPacman()
    {
        damageTaken.Invoke();
    }

    // Handles the event when the player falls from a platform
    void FallenGhostHandler()
    {
        if (availablePortals.isInPlaylistMode)
        {
            rb.velocity = Vector2.zero;
            transform.position = startPosition;
        }
        else
        {
            isPaused = true;
            //GameWinEvent.Invoke();
            GameObject objectiveFailed = Instantiate(objFailed);
        }
    }

    void FireProjectile()
    {
        firing = true;
        int flipped = isFlipped ? -1 : 1;

        GameObject projectile = Instantiate(energyBurst,
            new Vector3(transform.position.x + flipped * .38f, transform.position.y + .05f, 0f), Quaternion.identity, null);

        projectile.GetComponent<Rigidbody2D>().AddForce(Vector2.right * projectileForce * flipped, ForceMode2D.Impulse);
        StartCoroutine("FireDelayTimer");
    }

    IEnumerator FireDelayTimer()
    {
        yield return new WaitForSeconds(cooldownBetweenProjectiles);
        firing = false;
    }

    void FlipGhost()
    {
        Vector3 newScale = gameObject.transform.localScale;
        newScale.x *= -1;
        gameObject.transform.localScale = newScale;
    }

    // Returns whether or not a gamepad is connected
    bool CheckGamepadState()
    {
        if (Gamepad.current != null)
        {
            return true;
        }
        else return false;
    }

    // Update is called once per frame
    void Update()
    {
        // Don't run the update method if the game is paused
        if (isPaused) return;

        if (!gamepadMode)
        {
            shootButton = Input.GetKey(ControlScheme.Shoot);
            jumpButton = Input.GetKey(ControlScheme.Jump);
            moveLeftButton = Input.GetKey(ControlScheme.MoveLeft);
            moveRightButton = Input.GetKey(ControlScheme.MoveRight);
            moveLeftButtonUp = Input.GetKeyUp(ControlScheme.MoveLeft);
            moveRightButtonUp = Input.GetKeyUp(ControlScheme.MoveRight);
        }

        // Check for player firing
        if (shootButton && !firing)
        {
            FireProjectile();
        }

        // First, let's check if player is trying to jump
        if (jumpButton  && isGrounded)
        {
            rb.velocity += Vector2.up * 7.3f; // 5.5
            moveState = MoveStates.JUMPING;
        }

        if (moveState != MoveStates.FALLING && rb.velocity.y < 0f)
        {
            moveState = MoveStates.FALLING;
        }

        // If A or D key has just been released, then set horizontal curve to deceleration
        if (moveLeftButtonUp || moveRightButtonUp)
        {
            animator.SetBool("isLeaning", false);
            currentHCurve = decelerationCurve;
        }

        //Store the current horizontal input in the float moveHorizontal.
        //moveHorizontal = Input.GetAxis("Horizontal");

        if (moveLeftButton)
        {
            animator.SetBool("isLeaning", true);
            if (moveHorizontal > 0) moveHorizontal = 0;
            moveHorizontal += -Time.deltaTime;
            if (moveHorizontal < -1) moveHorizontal = -1;
        }

        else if (moveRightButton)
        {
            animator.SetBool("isLeaning", true);
            if (moveHorizontal < 0) moveHorizontal = 0;
            moveHorizontal += Time.deltaTime;
            if (moveHorizontal > 1) moveHorizontal = 1;
        }

        else
        {
            if (moveHorizontal > 0) moveHorizontal -= .05f;
            else if (moveHorizontal < 0) moveHorizontal += .05f;
            if (Mathf.Abs(moveHorizontal) <= .05f) moveHorizontal = 0;
        }

        if (moveHorizontal < 0 && !isFlipped)
        {
            FlipGhost();
            //sr.flipX = true;
            isFlipped = true;
        }
        else if (moveHorizontal > 0 && isFlipped)
        {
            FlipGhost();
            //sr.flipX = false;
            isFlipped = false;
        }

        switch (moveState)
        {
            case MoveStates.IDLE:

                // Make necessary horizontal movement
                transform.position += new Vector3(1, 0, 0) * currentHCurve.Evaluate(moveHorizontal) * translateSpeed * Time.deltaTime;

                // If no horizontal input, then return without doing anything
                if (moveHorizontal == 0) return;

                // If we've made it to this point in code, then the player has just pressed A or D
                // So let's set the currentcurve to acceleration curve
                currentHCurve = accelerationCurve;
             
                break;

            case MoveStates.JUMPING:

                // Make necessary vertical movement
                transform.position += new Vector3(1, 0, 0) * currentHCurve.Evaluate(moveHorizontal) * translateSpeed * Time.deltaTime;
                isGrounded = false;

                break;

            case MoveStates.FALLING:

                // Make necessary horizontal movement
                transform.position += new Vector3(1, 0, 0) * currentHCurve.Evaluate(moveHorizontal) * translateSpeed * Time.deltaTime;

                // Make necessarry vertical movement
                rb.velocity += Vector2.down * Time.deltaTime * (firing ? 0f : 5f);

                // If we've landed, then switch state to IDLE
                if (isGrounded)
                {
                    moveState = MoveStates.IDLE;
                    return;
                }
                break;
        }
    }
}
