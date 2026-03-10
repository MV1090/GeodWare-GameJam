using System.Collections;
using UnityEngine;

public class DrainWater : MonoBehaviour
{
    [SerializeField] FloatingPlatform floatingPlatform;

    public IEnumerator Drain()
    {

        StartCoroutine(floatingPlatform.FloatUp());

        Vector2 startPos = transform.position;
        Vector2 targetPos = startPos + Vector2.down * 5f;

        float duration = 2f;
        float time = 0f;

        while (time < duration)
        {
            transform.position = Vector2.Lerp(startPos, targetPos, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        
        transform.position = targetPos;
        Destroy(gameObject);
    }
}
