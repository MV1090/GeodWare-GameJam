using UnityEngine;
using UnityEngine.WSA;

public class LeverPull : MonoBehaviour, IResettable
{
    [SerializeField] GameObject[] effectedObjects;
    [SerializeField] LeverPull[] otherLevers;
    [SerializeField] Sprite pulledSprite;
  

    private SpriteRenderer sr;     

    public bool canBePulled = true;

    //Color originalColor;
    //bool originalFlipX;
    Sprite originalSprite;
    bool originalState;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void PullLever()
    {
        if (!canBePulled)
            return;        
           AudioManager.Instance.PlayLeverPull(); 
           AudioManager.Instance.PlaySpritesFall();

        ActivateOtherObjects();
        DisableOtherLevers();

        //sr.color = Color.red;
        //sr.flipX = false;
        sr.sprite = pulledSprite;
        canBePulled = false;
    }

    private void ActivateOtherObjects()
    {
        if (effectedObjects != null)
        {
            foreach (GameObject obj in effectedObjects)
            {
                Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
                rb.simulated = true;
            }
        }
    }

    void DisableOtherLevers()
    {
        if(otherLevers == null)
            return;

        foreach (LeverPull lever in otherLevers)
        {
            lever.canBePulled = false;
            //lever.sr.color = Color.red;
            lever.sr.sprite = pulledSprite;
        }
    }         

    public void SaveState()
    {
        //originalColor = sr.color;
        //originalFlipX = sr.flipX;
        originalSprite = sr.sprite;
        originalState = canBePulled;
    }

    public void ResetState()
    {
        //sr.color = originalColor;
        //sr.flipX = originalFlipX;
        sr.sprite = originalSprite;
        canBePulled = originalState;
    }
}
