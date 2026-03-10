using UnityEngine;

public class EarthSpriteAction : MonoBehaviour
{

    [SerializeField] GameObject platform;
     
   void OnTriggerEnter2D(Collider2D collision)
   {
        if (collision.gameObject.tag == "Spikes")
        {
            Instantiate(platform.gameObject, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
   }
}
