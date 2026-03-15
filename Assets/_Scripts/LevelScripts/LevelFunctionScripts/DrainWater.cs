using System.Collections;
using UnityEngine;

public class DrainWater : MonoBehaviour, IResettable
{
    private Vector2 originalPosition;
    public void SaveState()
    {
        originalPosition = transform.position;
    }

    public void ResetState()
    {
        StopAllCoroutines();
        transform.position = originalPosition;
    }

    [SerializeField] FloatingPlatform floatingPlatform;
    [SerializeField] float distance = 5f;
 
    public IEnumerator Drain(GameObject triggerObject)
    {
        if (floatingPlatform != null)
        StartCoroutine(floatingPlatform.FloatUp());

        Vector2 startPos = transform.position;
        Vector2 targetPos = startPos + Vector2.down * distance;

        float duration = 2f;
        float time = 0f;

        while (time < duration)
        {
            transform.position = Vector2.Lerp(startPos, targetPos, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        
        Destroy(triggerObject);

        transform.position = targetPos;
        gameObject.SetActive(false);
    }
}
