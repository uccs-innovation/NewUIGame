using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class playerController : MonoBehaviour
{
    GameObject objCanvas;

    //int pelletCount;

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

    // Are we currently in the process of firing?
    bool firing = false;

    [SerializeField]
    GameObject energyBurst; // prefab for the energy burst projectile

    // Gameover UI for when the player falls from a platform
    [SerializeField]
    GameObject objFailed;

    // The amount of force applied to projectiles
    float projectileForce = 8f;

    float cooldownBetweenProjectiles = .1f;

    SpriteRenderer sr;

    enum MoveStates
    {
        IDLE,
        JUMPING,
        FALLING
    }

    bool isGrounded = true;

    MoveStates moveState = MoveStates.IDLE;

    AvailablePortals availablePortals;


    // Start is called before the first frame update
    void Start()
    {
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
        BroadcastMessage("HandleHealthLoss");
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
            new Vector3(transform.position.x + flipped * .37f, transform.position.y + .24f, 0f), Quaternion.identity, null);

        projectile.GetComponent<Rigidbody2D>().AddForce(Vector2.right * projectileForce * flipped, ForceMode2D.Impulse);
        StartCoroutine("FireDelayTimer");
    }

    IEnumerator FireDelayTimer()
    {
        yield return new WaitForSeconds(cooldownBetweenProjectiles);
        firing = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Don't run the update method if the game is paused
        if (isPaused) return;

        // Check for player firing
        if (Input.GetKey(ControlScheme.Shoot) && !firing)
        {
            FireProjectile();
        }

        // First, let's check if player is trying to jump
        if (Input.GetKeyDown(ControlScheme.Jump)  && isGrounded)
        {
            rb.velocity += Vector2.up * 5.5f;
            moveState = MoveStates.JUMPING;
        }

        if (moveState != MoveStates.FALLING && rb.velocity.y < 0f)
        {
            moveState = MoveStates.FALLING;
        }

        // If A or D key has just been released, then set horizontal curve to deceleration
        if (Input.GetKeyUp(ControlScheme.MoveLeft) || Input.GetKeyUp(ControlScheme.MoveRight)) currentHCurve = decelerationCurve;

        //Store the current horizontal input in the float moveHorizontal.
        //moveHorizontal = Input.GetAxis("Horizontal");

        if (Input.GetKey(ControlScheme.MoveLeft))
        {
            if (moveHorizontal > 0) moveHorizontal = 0;
            moveHorizontal += -Time.deltaTime;
            if (moveHorizontal < -1) moveHorizontal = -1;
        }

        else if (Input.GetKey(ControlScheme.MoveRight))
        {
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
            sr.flipX = true;
            isFlipped = true;
        }
        else if (moveHorizontal > 0 && isFlipped)
        {
            sr.flipX = false;
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
                rb.velocity += Vector2.down * Time.deltaTime * (firing ? 0f : 35f);

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
