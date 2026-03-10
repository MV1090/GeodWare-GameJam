using System.Collections;
using UnityEngine;

public class WaterSpriteAction : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collided with: " + collision.gameObject.name);

        if (collision.gameObject.tag == "Water")
        {
            DrainWater drainWater = collision.gameObject.GetComponent<DrainWater>();

            StartCoroutine(drainWater.Drain()); 
            
            Destroy(gameObject, 1f);
        }
    }

    //IEnumerator DrainWater(Collider2D obj)
    //{
    //    Vector2 startPos = obj.transform.position;
    //    Vector2 targetPos = startPos + Vector2.down * 5f;

    //    float duration = 2f;
    //    float time = 0f;

    //    while (time < duration)
    //    {
    //        obj.transform.position = Vector2.Lerp(startPos, targetPos, time / duration);
    //        time += Time.deltaTime;
    //        yield return null;
    //    }
    //    Destroy(gameObject);
    //    obj.transform.position = targetPos;        
    //    Destroy(obj.gameObject);
    //}
}
