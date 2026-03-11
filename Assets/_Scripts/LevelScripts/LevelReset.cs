using UnityEngine;

public class LevelReset : MonoBehaviour
{
    public GameObject[] resettableObjects;

    public void ResetObjects()
    {
        foreach (GameObject resettable in resettableObjects)
        {
            if (resettable.TryGetComponent(out IResettable resettableComponent))
            {
                resettableComponent.ResetState();
            }
        }
    }

}
