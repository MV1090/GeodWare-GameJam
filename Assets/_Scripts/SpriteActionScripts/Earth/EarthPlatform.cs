using UnityEngine;

public class EarthPlatform : MonoBehaviour, IResettable
{
    public void SaveState()
    {
        // no Save State needed for this object
    }
    public void ResetState()
    {
        Destroy(gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
