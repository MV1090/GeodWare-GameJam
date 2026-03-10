using System.Collections;
using UnityEngine;

public class FloatingPlatform : MonoBehaviour
{
    public IEnumerator FloatUp()
    {
        Vector2 startPos = transform.position;
        Vector2 targetPos = startPos + Vector2.up * 4f;

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
