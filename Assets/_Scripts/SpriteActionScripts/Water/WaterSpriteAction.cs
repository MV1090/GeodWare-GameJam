using UnityEngine;

public class WaterSpriteAction : BaseSpriteAction, IResettable
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collided with: " + collision.gameObject.name);

        if (collision.gameObject.tag == "Water")
        {
            DrainWater drainWater = collision.gameObject.GetComponent<DrainWater>();
            AudioManager.Instance.PlayWaterDrop(transform.position);

            StartCoroutine(drainWater.Drain(gameObject)); 
            
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

            spriteRenderer.enabled = false; // Hide the sprite immediately

            //Destroy(gameObject, .5f);
        }

        if (collision.gameObject.tag == "Podium")
        {
            PodiumScript podiumScript = collision.gameObject.GetComponent<PodiumScript>();
            if (podiumScript != null && podiumScript.element == RescuedSprites.ElementSprite.Water)
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
        StopAllCoroutines();
        Destroy(gameObject);
    }

}
