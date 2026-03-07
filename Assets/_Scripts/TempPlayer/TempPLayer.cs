using UnityEngine;

public class TempPLayer : MonoBehaviour
{

    public static TempPLayer instance;

    public RescuedSprites rescuedSprites;

    [Header("Movement")]
    public float moveSpeed = 8f;

    [Header("Jump")]
    public float jumpForce = 12f;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool isGrounded;

    private float moveInput;

    void Awake()
    {        
        instance = this;
        rb = GetComponent<Rigidbody2D>();
        rescuedSprites = GetComponent<RescuedSprites>();
    }

    void Update()
    {
        HandleInput();
        HandleJump();
        //ChangeSpriteBasedOnState();
    }

    void FixedUpdate()
    {
        Move();
    }

    void HandleInput()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
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

    //void ChangeSpriteBasedOnState()
    //{
    //    if (Input.GetKeyDown("1")) 
    //    { 
    //        rescuedSprites.SetCurrentState(RescuedSprites.ElementSprite.Earth);
    //        return; 
    //    }

    //    if (Input.GetKeyDown("2"))
    //    {
    //        rescuedSprites.SetCurrentState(RescuedSprites.ElementSprite.Air);
    //        return;
    //    }

    //    if (Input.GetKeyDown("3"))
    //    {
    //        rescuedSprites.SetCurrentState(RescuedSprites.ElementSprite.Fire);
    //        return;
    //    }

    //    if (Input.GetKeyDown("4"))
    //    {
    //        rescuedSprites.SetCurrentState(RescuedSprites.ElementSprite.Water);
    //        return;
    //    }

    //    if (Input.GetKeyDown("5"))
    //    {
    //        rescuedSprites.SetCurrentState(RescuedSprites.ElementSprite.Default);
    //        return;
    //    }
    //}

    void OnDrawGizmosSelected()
    {
        if (groundCheck == null) return;

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}  

