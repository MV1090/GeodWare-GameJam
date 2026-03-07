using UnityEngine;

public class WaterSprite : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<TempPLayer>().rescuedSprites.SetCurrentState(RescuedSprites.ElementSprite.Water);

            Destroy(gameObject);
        }
    }
}
