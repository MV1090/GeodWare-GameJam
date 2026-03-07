using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Level_Catalog_Scriptable levelCatalog;


    private LevelSegments previousLevel;



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            LoadNextLevel(0);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            LoadNextLevel(1);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadNextLevel(2);
        }
        
    }

    
    private void LoadNextLevel(int levelToLoad)
    {      
               
        
        if (levelToLoad >= levelCatalog.allLevels.Count)
        {
            Debug.LogWarning("No more levels available. You have completed all levels!");
            return;
        }

        LoadLevel(levelCatalog.allLevels[levelToLoad]);
    }    

    private void LoadLevel(Level_Scriptable levelData)
    {
        GameObject nextLevelObj = Instantiate(levelData.level);

        LevelSegments nextLevel = nextLevelObj.GetComponent<LevelSegments>();

        if (previousLevel == null)
        {
            previousLevel = nextLevel;
            return;
        }

        Vector3 offset = previousLevel.exitPoint.position - nextLevel.entryPoint.position;

        nextLevelObj.transform.position += offset;

        previousLevel = nextLevel;
    }
}
