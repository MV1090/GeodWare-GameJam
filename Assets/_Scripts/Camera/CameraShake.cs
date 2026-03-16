using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    Vector3 originalPosition;    

    public IEnumerator Shake(float duration, float magnitude, System.Action onComplete)
    {             

        originalPosition = transform.localPosition;

        float elapsed = 0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = originalPosition + new Vector3(x, y, 0);            

            elapsed += Time.unscaledDeltaTime;

            yield return null;
        }

        

        transform.localPosition = originalPosition;           

        onComplete?.Invoke();
    }
}
