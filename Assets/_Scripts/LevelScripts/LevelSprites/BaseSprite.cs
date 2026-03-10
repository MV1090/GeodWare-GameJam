using UnityEngine;

public class BaseSprite : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Spikes")
        {
            Destroy(gameObject);
        }
    }
}
