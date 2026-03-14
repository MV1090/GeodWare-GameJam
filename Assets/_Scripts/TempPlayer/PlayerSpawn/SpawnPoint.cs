using System.Collections;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public int spawnPointID;

    public LevelReset levelReset;

    public RescuedSprites.ElementSprite savedElementState;
    
    public IEnumerator WaitForLoad()
    {
        spawnPointID = GameManager.instance.GetSpawnPointID() + 1;

        if (spawnPointID > GameManager.instance.GetSpawnPointID())
            GameManager.instance.SetCurrentSpawnPoint(this);

        yield return new WaitForSeconds(0.05f);

        foreach (GameObject resettable in levelReset.resettableObjects)
        {

            if (resettable.activeInHierarchy == false)
            {
                Debug.LogWarning("A resettable object in the levelReset script is null. Please check the inspector.");
                continue;
            }

            if (resettable.TryGetComponent(out IResettable resettableComponent))
            {              
                resettableComponent.SaveState();
                savedElementState = GameManager.instance.GetNextLevelElement();
            }
        }
    }
}