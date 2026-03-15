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
        GameManager.instance.OnStateChanged -= DestroyBlocker;
    }       

    void DestroyBlocker(RescuedSprites.ElementSprite element) 
    {
        if (GameManager.instance.pendingLevelElement == RescuedSprites.ElementSprite.Default)
        {
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
        TempPlayer.instance.rescuedSprites.OnStateChanged += DestroyBlocker;
    }
}
