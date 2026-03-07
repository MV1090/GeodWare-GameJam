using UnityEngine;

public class RescuedSprites : MonoBehaviour
{   
    public enum ElementSprite
    {
        Earth,
        Air,
        Fire,
        Water,
        Default
    }

    [SerializeField] private ElementSprite currentState = ElementSprite.Default;

    public ElementSprite GetCurrentState()
    {
        return currentState;
    }

    public void SetCurrentState(ElementSprite newState)
    {
        currentState = newState;
    }
}
