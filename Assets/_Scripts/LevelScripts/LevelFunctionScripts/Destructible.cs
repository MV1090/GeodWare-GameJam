using System;
using UnityEngine;

public class Destructible : MonoBehaviour, IResettable
{
    public event Action ObjectDestroyed;

    public void SaveState()
    {
        // No state to save for the destructible object, as it is either active or inactive based on whether it has been destroyed or not.
    }
    public void ResetState()
    {
        gameObject.SetActive(true);
    }

    public void OnDisable()
    {
        ObjectDestroyed?.Invoke();
    }


}
