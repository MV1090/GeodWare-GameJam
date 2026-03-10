using UnityEngine;

public class RemoveBlocker : MonoBehaviour
{    
    void Start()
    {
        TempPlayer.instance.rescuedSprites.OnStateChanged += DestroyBlocker;
    }

    void DestroyBlocker(RescuedSprites.ElementSprite element) 
    {
        Debug.Log("blocker should be destroyed");
        TempPlayer.instance.rescuedSprites.OnStateChanged -= DestroyBlocker;
        Destroy(gameObject);
    }
        
}
