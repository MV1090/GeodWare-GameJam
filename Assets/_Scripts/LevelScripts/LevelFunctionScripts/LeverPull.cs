using UnityEngine;

public class LeverPull : MonoBehaviour
{
    [SerializeField] GameObject[] effectedObjects;

    private SpriteRenderer sr;

    bool isPulled = false;

    public bool canBePulled = false;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void PullLever()
    {
        if (isPulled)
            return;

        sr.color = Color.red;
        sr.flipX = false;
        foreach (GameObject obj in effectedObjects)
        {            
            Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
            rb.gravityScale = 1f;
        }

        isPulled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canBePulled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canBePulled = false;
        }
    }

}
