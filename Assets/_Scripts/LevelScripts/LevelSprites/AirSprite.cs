using UnityEngine;

public class AirSprite : BaseSprite
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<TempPlayer>().rescuedSprites.SetCurrentState(RescuedSprites.ElementSprite.Air);

            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "MovingPlatform")
        {
            gameObject.transform.SetParent(collision.transform);
        }
    }
}
