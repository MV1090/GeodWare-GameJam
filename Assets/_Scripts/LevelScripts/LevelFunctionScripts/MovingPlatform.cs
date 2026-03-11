using UnityEngine;

public class MovingPlatform : MonoBehaviour, IResettable
{
    public float moveDistance = 5f;
    public float moveSpeed = 2f;

    public bool moveHorizontal = false;
    public bool moveVertical = false;

    private Rigidbody2D rb;
    private Vector2 previousPos;
    private Vector2 moveDelta;
    private Vector2 startPos;
    private Vector2 targetPos;
    private int direction = 1;

    private bool isMoving;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;

        if (moveHorizontal)
            targetPos = startPos + Vector2.right * moveDistance;
        else if (moveVertical)
            targetPos = startPos + Vector2.up * moveDistance;

        previousPos = rb.position;
    }

    void FixedUpdate()
    {
        Vector2 newPos = Vector2.MoveTowards(rb.position, targetPos, moveSpeed * Time.fixedDeltaTime);
        moveDelta = newPos - previousPos;

        rb.MovePosition(newPos);

        previousPos = newPos;

        if (moveHorizontal)
        {
            MoveHorizontal();
            
            return;
        }

        if (moveVertical)
        {
            MoveVertical();
            
            return;
        }
        
    }

    private void MoveHorizontal()
    {
        if (Vector2.Distance(rb.position, targetPos) < 0.01f)
        {
            direction *= -1;
            targetPos = (direction == 1) ? startPos + Vector2.right * moveDistance : startPos;
        }
    }

    private void MoveVertical()
    {
        if (Vector2.Distance(rb.position, targetPos) < 0.01f)
        {
            direction *= -1;
            targetPos = (direction == 1) ? startPos + Vector2.up * moveDistance : startPos;
        }       
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Rigidbody2D rbPlayer = collision.gameObject.GetComponent<Rigidbody2D>();
        if (rbPlayer != null)
        {

            foreach (ContactPoint2D contact in collision.contacts)
            {
                if (contact.normal.y > 0.9f)
                {
                    rbPlayer.position += moveDelta;
                }
            }
        }
    }

    public void SaveState()
    {
        startPos = transform.position;
        isMoving = rb.simulated;
    }

    public void ResetState()
    {
        transform.position = startPos;
        rb.simulated = isMoving;
    }
}
