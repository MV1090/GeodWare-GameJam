using UnityEngine;

public class EarthSprite : BaseSprite
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // 🔊 Play pickup sound at sprite location
            AudioManager.Instance.PlaySpriteCollect(transform.position);

            if (!GameManager.instance.levelLockedIn)
                collision.gameObject.GetComponent<TempPlayer>().rescuedSprites.SetCurrentState(RescuedSprites.ElementSprite.Earth);

            gameObject.SetActive(false);
        }

        if (collision.gameObject.tag == "MovingPlatform")
        {
            gameObject.transform.SetParent(collision.transform);
        }
    }
}
