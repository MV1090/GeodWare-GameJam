using UnityEngine;
using FMODUnity;

public class FMODTest : MonoBehaviour
{
    [SerializeField] private EventReference testEvent;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RuntimeManager.PlayOneShot(testEvent);
        }
    }
}
