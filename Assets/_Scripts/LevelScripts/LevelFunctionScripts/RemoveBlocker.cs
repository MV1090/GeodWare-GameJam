using UnityEngine;

public class RemoveBlocker : MonoBehaviour, IResettable
{

    [SerializeField] GameObject blockerText;

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            blockerText.SetActive(true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            blockerText.SetActive(false);
        }
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
