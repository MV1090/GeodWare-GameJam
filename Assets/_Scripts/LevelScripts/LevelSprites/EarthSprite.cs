using UnityEngine;

public class EarthSprite : BaseSprite
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<TempPLayer>().rescuedSprites.SetCurrentState(RescuedSprites.ElementSprite.Fire);

            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "MovingPlatform")
        {
            gameObject.transform.SetParent(collision.transform);
        }
    }
}
