using UnityEngine;

public class RemoveBlocker : MonoBehaviour, IResettable
{    
    void Start()
    {
        //TempPlayer.instance.rescuedSprites.OnStateChanged += DestroyBlocker;
        GameManager.instance.OnStateChanged += DestroyBlocker;
    }

    void DestroyBlocker(RescuedSprites.ElementSprite element) 
    {
        if (GameManager.instance.pendingLevelElement == RescuedSprites.ElementSprite.Default)
        {
            gameObject.SetActive(true);
            return;
        }

        Debug.Log("blocker should be destroyed");
        //TempPlayer.instance.rescuedSprites.OnStateChanged -= DestroyBlocker;

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
