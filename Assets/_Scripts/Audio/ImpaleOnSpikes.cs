using UnityEngine;

public class PlayImpaleNearSurface : MonoBehaviour
{
    [SerializeField] private float triggerDistance = 0.5f;
    [SerializeField] private LayerMask solidLayerMask;

    private bool hasPlayed = false;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (hasPlayed || rb == null)
            return;

        // Only check while falling downward
        if (rb.linearVelocity.y >= 0f)
            return;

        RaycastHit2D hit = Physics2D.Raycast(
            transform.position,
            Vector2.down,
            triggerDistance,
            solidLayerMask
        );

        if (hit.collider != null)
        {
            hasPlayed = true;
            AudioManager.Instance.PlayImpale(transform.position);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * triggerDistance);
    }
}