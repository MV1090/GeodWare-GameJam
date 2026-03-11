using UnityEngine;

public class WaterSprite : BaseSprite
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!GameManager.instance.levelLockedIn)
                collision.gameObject.GetComponent<TempPlayer>().rescuedSprites.SetCurrentState(RescuedSprites.ElementSprite.Water);

            gameObject.SetActive(false);
        }

        if (collision.gameObject.tag == "MovingPlatform")
        {
            gameObject.transform.SetParent(collision.transform);
        }
    }
}
