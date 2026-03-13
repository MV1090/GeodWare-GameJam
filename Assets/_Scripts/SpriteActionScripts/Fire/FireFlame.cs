using System.Collections;
using UnityEngine;

public class FireFlame : MonoBehaviour, IResettable
{

    public void SaveState()
    {
        // No state to save for this object
    }

    public void ResetState()
    {
        Destroy(gameObject);
    }

    private void OnEnable()
    {        
        // 🔥 Start fire loop sound
        AudioManager.Instance.StartFireLoop(gameObject);

        StartCoroutine(GrowOverTime(2f));             
    }

    

    IEnumerator GrowOverTime(float duration)
    {
        Vector2 originalSize = new Vector2(transform.localScale.x / 3f, transform.localScale.y / 4f);
        Vector2 targetSize = originalSize * 2.5f;
        float time = 0f;

        while (time < duration)
        {
            transform.localScale = Vector2.Lerp(originalSize, targetSize, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        
        transform.localScale = targetSize;   

        // 🔥 Stop fire loop with fadeout
        AudioManager.Instance.StopFireLoop();
             
        transform.parent.gameObject.SetActive(false);
    }
}
