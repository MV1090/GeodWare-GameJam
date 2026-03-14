using UnityEngine;

public class AirSpriteAction : BaseSpriteAction
{
    [SerializeField] AirBooster booster;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 3)
        {            
            Instantiate(booster.gameObject, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
                
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Podium")
        {
            PodiumScript podiumScript = collision.gameObject.GetComponent<PodiumScript>();
            if (podiumScript != null && podiumScript.element == RescuedSprites.ElementSprite.Air)
            {
                podiumScript.SetActivated();
            }
            Destroy(gameObject);
        }
    }
}


