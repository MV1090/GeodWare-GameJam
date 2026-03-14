using UnityEngine;

public class FireSpriteAction : BaseSpriteAction
{
    [SerializeField] FireFlame fireFlame;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Crate")
        {
            GameObject fire;
            fire = Instantiate(fireFlame.gameObject, new Vector3(collision.gameObject.transform.position.x, 
                collision.gameObject.transform.position.y - collision.gameObject.transform.localScale.y * 0.25f, 
                collision.gameObject.transform.position.z), Quaternion.identity);

            fire.transform.SetParent(collision.gameObject.transform);
            Destroy(gameObject);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Podium")
        {
            PodiumScript podiumScript = collision.gameObject.GetComponent<PodiumScript>();
            if (podiumScript != null && podiumScript.element == RescuedSprites.ElementSprite.Fire)
            {
                podiumScript.SetActivated();
            }
            Destroy(gameObject);
        }
    }

}
