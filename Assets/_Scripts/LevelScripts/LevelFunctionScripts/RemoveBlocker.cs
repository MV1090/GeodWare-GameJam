using UnityEngine;

public class RemoveBlocker : MonoBehaviour, IResettable
{    
    void Start()
    {
        TempPlayer.instance.rescuedSprites.OnStateChanged += DestroyBlocker;
    }

    void DestroyBlocker(RescuedSprites.ElementSprite element) 
    {
        Debug.Log("blocker should be destroyed");
        TempPlayer.instance.rescuedSprites.OnStateChanged -= DestroyBlocker;
        gameObject.SetActive(false);
    }

    public void SaveState()
    {
        
    }

    public void ResetState()
    {
        gameObject.SetActive(true);
        TempPlayer.instance.rescuedSprites.OnStateChanged += DestroyBlocker;
    }
}
