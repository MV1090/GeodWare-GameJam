using UnityEngine;

public class EarthSprite : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<TempPLayer>().rescuedSprites.SetCurrentState(RescuedSprites.ElementSprite.Earth);

            Destroy(gameObject);
        }
    }
}
