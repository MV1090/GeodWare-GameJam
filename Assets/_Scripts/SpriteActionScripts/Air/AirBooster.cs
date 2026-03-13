using UnityEngine;

public class AirBooster : MonoBehaviour, IResettable
{
    public void SaveState()
    {
        // no Save State needed for this object
    }

    public void ResetState()
    {
        Destroy(gameObject);
    }
   
    [SerializeField] private float boostForce = 20f;
    
    void Start()
    {
        Invoke(nameof(PlaySuccessSound), 0.7f);
        Destroy(gameObject, 5f);
    }
    void PlaySuccessSound()
    {
        AudioManager.Instance.PlaySpriteSuccess();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Rigidbody2D playerRb = collision.GetComponent<Rigidbody2D>();

            float turbulence = Random.Range(-1f, 1f);
            playerRb.linearVelocity = new Vector2(playerRb.linearVelocity.x, boostForce);
            playerRb.gravityScale = 0.3f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Rigidbody2D playerRb = collision.GetComponent<Rigidbody2D>();
           playerRb.gravityScale = 3f;
        }
    }
}
