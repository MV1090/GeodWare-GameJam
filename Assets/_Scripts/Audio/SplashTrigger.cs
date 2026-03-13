using UnityEngine;

public class SplashTrigger : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D other)
   {
        Rigidbody2D rb = other.attachedRigidbody;

        if (rb != null)
        {
            AudioManager.Instance.PlaySplash(other.transform.position);
        }
   }
}