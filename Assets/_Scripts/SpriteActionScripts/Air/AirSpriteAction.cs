using UnityEngine;

public class AirSpriteAction : MonoBehaviour
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
    
}
