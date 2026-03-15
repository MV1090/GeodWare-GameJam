using UnityEngine;

public class RemoveBlocker : MonoBehaviour, IResettable
{    
    void Start()
    {
        
    }

    private void OnEnable()
    {        
        GameManager.instance.OnStateChanged += DestroyBlocker;
    }

    private void OnDisable()
    {
        if (GameManager.instance != null)
            GameManager.instance.OnStateChanged -= DestroyBlocker;
        //UnsubscribeFromRescuedSprites();
    }

    //private void OnDestroy()
    //{
    //    if (GameManager.instance != null)
    //        GameManager.instance.OnStateChanged -= DestroyBlocker;
    //    //UnsubscribeFromRescuedSprites();
    //}

    //private void UnsubscribeFromRescuedSprites()
    //{
    //    if (TempPlayer.instance != null && TempPlayer.instance.rescuedSprites != null)
    //        TempPlayer.instance.rescuedSprites.OnStateChanged -= DestroyBlocker;
    //}

    void DestroyBlocker(RescuedSprites.ElementSprite element) 
    {
        if (this == null) return;
        if (GameManager.instance.pendingLevelElement == RescuedSprites.ElementSprite.Default)
        {
            if (gameObject == null)
                return;
            gameObject.SetActive(true);
            return;
        }

        Debug.Log("blocker should be destroyed");
        

        gameObject.SetActive(false);
    }

    public void SaveState()
    {
        
    }

    public void ResetState()
    {
        gameObject.SetActive(true);
        //TempPlayer.instance.rescuedSprites.OnStateChanged += DestroyBlocker;
    }
}
