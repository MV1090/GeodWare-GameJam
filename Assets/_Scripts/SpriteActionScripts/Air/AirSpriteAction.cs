using UnityEngine;

public class AirSpriteAction : BaseSpriteAction
{
    [SerializeField] AirBooster booster;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 3)
        {   
            AudioManager.Instance.PlayCreateWhirlwind(transform.position);         
            Instantiate(booster.gameObject, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }     
    
}
