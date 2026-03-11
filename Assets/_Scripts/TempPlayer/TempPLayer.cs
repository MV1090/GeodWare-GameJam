using UnityEngine;

public class TempPlayer : MonoBehaviour
{

    public static TempPlayer instance;

    public RescuedSprites rescuedSprites;
    private FireProjectile fireProjectile;

    [Header("Movement")]
    public float moveSpeed = 8f;

    [Header("Jump")]
    public float jumpForce = 12f;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private bool isGrounded;

    public bool isDead;

    private float moveInput;

    void Awake()
    {        
        instance = this;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        rescuedSprites = GetComponent<RescuedSprites>();
        fireProjectile = GetComponent<FireProjectile>();
    }

    private void Start()
    {
        GameManager.instance.RegisterPlayer(rescuedSprites);
    }

    void Update()
    {
        HandleInput();
        HandleJump();
        PullLever();
        Fire();
        ResetPlayer();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Fire() 
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {            
            if (fireProjectile != null)
            {
                fireProjectile.Fire();
            }
        }
    }

    void HandleInput()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        if(moveInput !=0) sr.flipX = moveInput < 0;
    }

    void Move()
    {
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
    }

    void HandleJump()
    {
        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            groundCheckRadius,
            groundLayer
        );

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }       

    void OnDrawGizmosSelected()
    {
        if (groundCheck == null) return;

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
       
    void PullLever()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, 0.5f);
            foreach (var hit in hits)
            {
                LeverPull lever = hit.GetComponent<LeverPull>();
                if (lever != null)
                {
                    lever.PullLever();
                    break;
                }
            }
        }
    }

    public void ResetPlayer()
    {
        if (Input.GetKeyDown(KeyCode.R) || isDead == true)
        {
            transform.position = GameManager.instance.GetCurrentSpawnPoint().transform.position;
            rescuedSprites.SetCurrentState(GameManager.instance.GetCurrentSpawnPoint().savedElementState);
            GameManager.instance.GetCurrentSpawnPoint().levelReset.ResetObjects();
            GameManager.instance.ClearNextLevel();
            isDead = false;
        }
    }
}  

