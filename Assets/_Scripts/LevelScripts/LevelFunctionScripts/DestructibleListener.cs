using UnityEngine;

public class DestructibleListener : MonoBehaviour
{
    [SerializeField] Destructible objDestroyed;

    void Start()
    {
        objDestroyed.ObjectDestroyed += RemoveObject;
    }

    void OnDisable()
    {
        objDestroyed.ObjectDestroyed -= RemoveObject;
    }

    private void RemoveObject()
    {
        gameObject.SetActive(false);
    }
}


