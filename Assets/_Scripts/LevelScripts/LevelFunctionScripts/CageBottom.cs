using UnityEngine;

public class CageBottom : MonoBehaviour, IResettable
{
    private Vector2 originalPosition;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void SaveState()
    {
        originalPosition = transform.position;
    }

    public void ResetState()
    {
        gameObject.SetActive(true);
        rb.simulated = false;
        transform.position = originalPosition;    
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.SetActive(false);
    }

}
