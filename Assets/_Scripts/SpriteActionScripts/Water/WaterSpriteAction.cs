using System.Collections;
using UnityEngine;

public class WaterSpriteAction : BaseSpriteAction
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collided with: " + collision.gameObject.name);

        if (collision.gameObject.tag == "Water")
        {
            DrainWater drainWater = collision.gameObject.GetComponent<DrainWater>();
            AudioManager.Instance.PlayWaterDrop(transform.position);

            StartCoroutine(drainWater.Drain()); 
            
            Destroy(gameObject, .5f);

            
        }
    }
        
}
