using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public Level_Catalog_Scriptable levelCatalog;
    private LevelSegments previousLevel;
    private HashSet<Level_Scriptable> loadedLevels = new HashSet<Level_Scriptable>();

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        if (levelCatalog == null || levelCatalog.allLevels.Count == 0)
        {
            Debug.LogError("Level Catalog is not assigned or contains no levels. Please assign a Level Catalog with levels.");
            return;
        }

        LoadLevel(levelCatalog.allLevels[0]);
        loadedLevels.Add(levelCatalog.allLevels[0]);
    }

    private void Update()
    {
              
    }

    public void LoadNextLevelByType(string levelType)
    {
        Level_Scriptable levelToLoad = levelCatalog.allLevels
            .Where(level => level.levelType == levelType && !loadedLevels.Contains(level))
            .OrderBy(level => level.levelId)
            .FirstOrDefault();

        if (levelToLoad != null)
        {
            LoadLevel(levelToLoad);
            loadedLevels.Add(levelToLoad);
        }
        else
        {
            Debug.LogWarning($"No incomplete levels of type {levelType}");
        }
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

        AlignLevels(previousLevel, nextLevel);

        previousLevel = nextLevel;

    }

    private void AlignLevels(LevelSegments from, LevelSegments to)
    {
        Vector3 offset = from.exitPoint.position - to.entryPoint.position;
        to.transform.position += offset;
    }
}
