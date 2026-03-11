using UnityEngine;

public class FireProjectile : MonoBehaviour
{
    [SerializeField] GameObject[] projectileList;
    [SerializeField] Transform firePointRight;
    [SerializeField] Transform firePointLeft;
    [SerializeField] int numberOfProjectiles = 0;
    [SerializeField] private GameObject currentProjectile;

    private SpriteRenderer spriteRenderer;

    [SerializeField] float xVelocity = 7.0f;
    [SerializeField] float yVelocity = 7.0f;

    private void Start()
    {
        TempPlayer.instance.rescuedSprites.OnStateChanged += SetCurrentProjectile;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnDisable()
    {
        TempPlayer.instance.rescuedSprites.OnStateChanged -= SetCurrentProjectile;
    }

    public void SetCurrentProjectile(RescuedSprites.ElementSprite element) 
    {
        if (element == RescuedSprites.ElementSprite.Default)
        {
            Debug.Log("No projectile available for Default state.");
            currentProjectile = null;
            numberOfProjectiles = 0;
            return;
        }

        Debug.Log($"Setting current projectile for element: {element}");
        numberOfProjectiles = 1;
        currentProjectile = projectileList[(int)element];
    }

    public GameObject GetCurrentProjectile()
    {
        return currentProjectile;
    }

    public void Fire()
    {
        if (currentProjectile == null) return;

        if (numberOfProjectiles <= 0)
        {
            Debug.Log("No projectiles left to fire.");
            return;
        }

        numberOfProjectiles--;

        if (!spriteRenderer.flipX)
        {
            GameObject projectile = Instantiate(currentProjectile, firePointRight.position, Quaternion.identity);

            BaseSpriteAction projectileAction = projectile.GetComponent<BaseSpriteAction>();
            projectileAction.xVel = xVelocity;
            projectileAction.yVel = yVelocity;
        }
        else
        {
            GameObject projectile = Instantiate(currentProjectile, firePointLeft.position, Quaternion.identity);

            BaseSpriteAction projectileAction = projectile.GetComponent<BaseSpriteAction>();
            projectileAction.xVel = xVelocity * -1;
            projectileAction.yVel = yVelocity;
        }

        TempPlayer.instance.rescuedSprites.SetCurrentState(RescuedSprites.ElementSprite.Default);
    }
}
