using System;
using UnityEngine;

public class RescuedSprites : MonoBehaviour
{   
    public enum ElementSprite
    {
        Default,
        Earth,
        Air,
        Fire,
        Water        
    }

    [SerializeField] private ElementSprite currentState = ElementSprite.Default;

    public event Action<ElementSprite> OnStateChanged;

    public ElementSprite GetCurrentState()
    {
        return currentState;
    }

    public void SetCurrentState(ElementSprite newState)
    {
        currentState = newState;

        OnStateChanged?.Invoke(currentState);
    }
}
