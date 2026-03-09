using UnityEngine;

public class FireProjectile : MonoBehaviour
{
    [SerializeField] GameObject[] projectileList;
    [SerializeField] Transform firePoint;
    [SerializeField] int numberOfProjectiles = 0;
    private GameObject currentProjectile;

    private void Start()
    {
        TempPlayer.instance.rescuedSprites.OnStateChanged += SetCurrentProjectile;
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
            return;
        }

        Debug.Log($"Setting current projectile for element: {element}");
        numberOfProjectiles = 1;
        currentProjectile = projectileList[(int)element];
    }

    public void Fire()
    {
        if (currentProjectile == null) return;

        numberOfProjectiles--;
        Instantiate(currentProjectile, firePoint.position, Quaternion.identity);
        TempPlayer.instance.rescuedSprites.SetCurrentState(RescuedSprites.ElementSprite.Default);
    }
}
