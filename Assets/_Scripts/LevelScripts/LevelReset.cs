using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelReset : MonoBehaviour
{
    public GameObject[] resettableObjects;

    public void ResetObjects()
    {
        HashSet<IResettable> processed = new();

        foreach (GameObject resettable in resettableObjects)
        {          
            if (resettable.TryGetComponent(out IResettable resettableComponent))
            {
                resettableComponent.ResetState();
                processed.Add(resettableComponent);
            }
        }

        foreach (var resettable in FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None).OfType<IResettable>())
        {
            if (!processed.Contains(resettable))
            {
                resettable.ResetState();
            }
        }
    }

}
