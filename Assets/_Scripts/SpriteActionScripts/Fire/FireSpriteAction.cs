using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class FireSpriteAction : MonoBehaviour
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
    
}
