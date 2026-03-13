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
        transform.position = originalPosition;
    }

    [SerializeField] FloatingPlatform floatingPlatform;
    [SerializeField] float distance = 5f;
    [SerializeField] float drainDuration = 2f;

    public IEnumerator Drain()
    {
        Debug.Log("Drain started");

        StartCoroutine(PlayDrainSoundDelayed());

        if (floatingPlatform != null)
            StartCoroutine(floatingPlatform.FloatUp());

        Vector2 startPos = transform.position;
        Vector2 targetPos = startPos + Vector2.down * distance;

        float time = 0f;

        while (time < drainDuration)
        {
            transform.position = Vector2.Lerp(startPos, targetPos, time / drainDuration);
            time += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;
        gameObject.SetActive(false);
    }

    private IEnumerator PlayDrainSoundDelayed()
    {
        yield return new WaitForSeconds(drainDuration);
        AudioManager.Instance.PlaySpriteSuccess();
    }
}
