using UnityEngine;

public class Crate : MonoBehaviour, IResettable
{
    public void SaveState()
    {

    }

    public void ResetState()
    {
        //GameObject childObj = transform.GetChild(0).gameObject;
        //if (childObj != null)
        //    Destroy(childObj);
        gameObject.SetActive(true);
    }
}
