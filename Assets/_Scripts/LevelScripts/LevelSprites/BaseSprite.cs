using UnityEngine;

public class BaseSprite : MonoBehaviour, IResettable
{
    Vector2 startPos;
    Rigidbody2D rb;

    bool rbSimulation;
    bool isActive;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rbSimulation = rb.simulated;        
    }

    public void SaveState()
    {
        isActive = gameObject.activeSelf;
        startPos = transform.position;
        rbSimulation = rb.simulated;
    }

    public void ResetState()
    {
        gameObject.SetActive(isActive);
        if (!isActive)
            return;

        transform.position = startPos;
        rb.simulated = rbSimulation;
       //gameObject.SetActive(true);
        if (transform.parent != null)
            transform.SetParent(null);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Spikes")
        {
            gameObject.SetActive(false);
        }

        if(collision.gameObject.tag == "Water")
        {
            gameObject.SetActive(false);
        }

        if (collision.gameObject.tag == "Podium")
        {
            if (collision.gameObject.TryGetComponent(out PodiumScript podiumScript))
            {
                podiumScript.SetActivated();
                gameObject.SetActive(false);
            }
        }


    }
}
