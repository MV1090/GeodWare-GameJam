using UnityEngine;
using UnityEngine.WSA;

public class LeverPull : MonoBehaviour, IResettable
{
    [SerializeField] GameObject[] effectedObjects;
    [SerializeField] LeverPull[] otherLevers;
  

    private SpriteRenderer sr;     

    public bool canBePulled = true;

    Color originalColor;
    bool originalFlipX;
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

        ActivateOtherObjects();
        DisableOtherLevers();

        sr.color = Color.red;
        sr.flipX = false;
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
            lever.sr.color = Color.red;
        }
    }

    public void SaveState()
    {
        originalColor = sr.color;
        originalFlipX = sr.flipX;
        originalState = canBePulled;
    }

    public void ResetState()
    {
        sr.color = originalColor;
        sr.flipX = originalFlipX;
        canBePulled = originalState;
    }
}
