using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public bool isDead = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Spikes") || collision.CompareTag("Water") || collision.CompareTag("DeathZone"))
        {
            TempPlayer.instance.isDead = true;
            TempPlayer.instance.ResetPlayer();
        }            
    }
}
