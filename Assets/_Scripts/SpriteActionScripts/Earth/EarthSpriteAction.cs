using UnityEngine;

public class EarthSpriteAction : BaseSpriteAction, IResettable
{

    [SerializeField] GameObject platform;
     
   void OnTriggerEnter2D(Collider2D collision)
   {
        if (collision.gameObject.tag == "Spikes")
        {
            Instantiate(platform.gameObject, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Podium")
        {
            PodiumScript podiumScript = collision.gameObject.GetComponent<PodiumScript>();
            if (podiumScript != null && podiumScript.element == RescuedSprites.ElementSprite.Earth)
            {
                podiumScript.SetActivated();
            }
            Destroy(gameObject);
        }
   }

    public void SaveState()
    {
        // No state to save for this object
    }

    public void ResetState()
    {
        Destroy(gameObject);
    }

}
