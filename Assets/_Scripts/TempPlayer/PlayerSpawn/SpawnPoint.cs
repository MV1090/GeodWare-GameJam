using System.Collections;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public int spawnPointID;

    public LevelReset levelReset;   


    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            spawnPointID = GameManager.instance.GetSpawnPointID() + 1;

            if (spawnPointID > GameManager.instance.GetSpawnPointID())
                GameManager.instance.SetCurrentSpawnPoint(this);

            StartCoroutine(WaitForLoad());          
            
        }
    }

    IEnumerator WaitForLoad()
    {
        yield return new WaitForSeconds(0.05f);

        foreach (GameObject resettable in levelReset.resettableObjects)
        {
            if (resettable.TryGetComponent(out IResettable resettableComponent))
            {
                resettableComponent.SaveState();                
            }
        }
    }
}