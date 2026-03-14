using UnityEngine;
using System;

public class PodiumScript : MonoBehaviour, IResettable
{
    [SerializeField] Color activatedColor;
    public RescuedSprites.ElementSprite element;
    SpriteRenderer sr;

    Color originalColor;

    public event Action<bool> OnActivated;       

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

    }

    public void SetActivated()
    {
        sr.color = activatedColor;
        OnActivated?.Invoke(true);
    }

    public void SaveState()
    {
        originalColor = sr.color;
    }

    public void ResetState()
    {
        sr.color = originalColor;
    }
       
}
