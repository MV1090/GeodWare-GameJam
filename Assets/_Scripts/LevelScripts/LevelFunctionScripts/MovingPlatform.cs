using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float moveDistance = 5f;
    public float moveSpeed = 2f;

    private Rigidbody2D rb;
    private Vector2 previousPos;
    private Vector2 moveDelta;
    private Vector3 startPos;
    private Vector3 targetPos;
    private int direction = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
        targetPos = startPos + Vector3.right * moveDistance;
        previousPos = rb.position;
    }

    void FixedUpdate()
    {
        Vector2 newPos = Vector2.MoveTowards(rb.position, targetPos, moveSpeed * Time.fixedDeltaTime);
        moveDelta = newPos - previousPos;

        rb.MovePosition(newPos);

        previousPos = newPos;

        
        if (Vector2.Distance(rb.position, targetPos) < 0.01f)
        {
            direction *= -1;
            targetPos = (direction == 1) ? startPos + Vector3.right * moveDistance : startPos;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Rigidbody2D rbPlayer = collision.rigidbody;
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
}
