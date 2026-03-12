using UnityEngine;

public class EarthSpriteAction : BaseSpriteAction
{

    [SerializeField] GameObject platform;
     
   void OnTriggerEnter2D(Collider2D collision)
   {
        if (collision.gameObject.tag == "Spikes")
        {
            AudioManager.Instance.PlayBuildPlatform(transform.position);
            Instantiate(platform.gameObject, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
   }
}
