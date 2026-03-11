using UnityEngine;

public class FireSprite : BaseSprite
{    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<TempPlayer>().rescuedSprites.SetCurrentState(RescuedSprites.ElementSprite.Fire);

            gameObject.SetActive(false);
        }

        if (collision.gameObject.tag == "MovingPlatform")
        {
            gameObject.transform.SetParent(collision.transform);
        }
    }
}
