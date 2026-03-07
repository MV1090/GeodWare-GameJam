using UnityEngine;

public class AirSprite : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<TempPLayer>().rescuedSprites.SetCurrentState(RescuedSprites.ElementSprite.Air);

            Destroy(gameObject);
        }
    }
}
