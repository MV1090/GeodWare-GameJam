using UnityEngine;

public class EarthPlatform : MonoBehaviour, IResettable
{
    public void SaveState()
    {
        // no Save State needed for this object
    }
    public void ResetState()
    {
        Destroy(gameObject, 10f);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
