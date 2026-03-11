using UnityEngine;

public class BaseSpriteAction : MonoBehaviour
{
    [HideInInspector] public float xVel;
    [HideInInspector] public float yVel;

    public float lifeTime;

    void Start()
    {
        GetComponent<Rigidbody2D>().linearVelocity = new Vector2(xVel, yVel/ 2);

        if (lifeTime <= 0)
            lifeTime = 2.0f;

        Destroy(gameObject, lifeTime);
    }

}
