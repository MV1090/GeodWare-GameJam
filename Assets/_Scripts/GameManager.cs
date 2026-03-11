using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public GameManager instance;

    SpawnPoint currentSpawnPoint;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetCurrentSpawnPoint(SpawnPoint spawnPoint)
    {
        currentSpawnPoint = spawnPoint;
    } 

    public SpawnPoint GetCurrentSpawnPoint()
    {
        return currentSpawnPoint;
    }

    public int GetSpawnPointID()
    {
        if(currentSpawnPoint == null)
            return -1;

        return currentSpawnPoint.spawnPointID;
    }
}
