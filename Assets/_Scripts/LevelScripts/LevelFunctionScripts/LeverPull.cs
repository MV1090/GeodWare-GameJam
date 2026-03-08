using UnityEngine;
using UnityEngine.WSA;

public class LeverPull : MonoBehaviour
{
    [SerializeField] GameObject[] effectedObjects;
    [SerializeField] LeverPull[] otherLevers;

    private SpriteRenderer sr;     

    public bool canBePulled = true;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void PullLever()
    {
        if (!canBePulled)
            return;        

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

}
