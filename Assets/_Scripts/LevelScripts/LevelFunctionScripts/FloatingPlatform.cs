using System.Collections;
using UnityEngine;

public class FloatingPlatform : MonoBehaviour, IResettable
{
    private Vector2 originalPosition;

    [SerializeField] float distance = 4f;

    public void SaveState()
    {
        originalPosition = transform.position;
    }

    public void ResetState()
    {
        transform.position = originalPosition;
    }

    public IEnumerator FloatUp()
    {
        Vector2 startPos = transform.position;
        Vector2 targetPos = startPos + Vector2.up * distance;

        float duration = 2f;
        float time = 0f;

        while (time < duration)
        {
            transform.position = Vector2.Lerp(startPos, targetPos, time / duration);
            time += Time.deltaTime;
            yield return null;
        }        
    }
}
