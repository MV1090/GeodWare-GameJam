using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;


public class LevelManager : MonoBehaviour
{
    public static LevelManager instance { get; private set; }

    public Level_Catalog_Scriptable levelCatalog;
    private LevelSegments previousLevel;
    private HashSet<Level_Scriptable> loadedLevels = new HashSet<Level_Scriptable>();
    [SerializeField] private List<GameObject> activeLevelRefs = new List<GameObject>();

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

        RandomizeLevels();
    }

    private void Start()
    {
        //if (levelCatalog == null || levelCatalog.allLevels.Count == 0)
        //{
        //    Debug.LogError("Level Catalog is not assigned or contains no levels. Please assign a Level Catalog with levels.");
        //    return;
        //}
                        
        //LoadLevel(levelCatalog.allLevels[0]);
        //loadedLevels.Add(levelCatalog.allLevels[0]);
        //TempPlayer.instance.transform.position = previousLevel.spawnPoint.position;
    }

    public void LoadFirstLevel()
    {
        if (levelCatalog == null || levelCatalog.allLevels.Count == 0)
        {
            Debug.LogError("Level Catalog is not assigned or contains no levels. Please assign a Level Catalog with levels.");
            return;
        }

        ResetLevels();
        LoadLevel(levelCatalog.allLevels[0]);
        loadedLevels.Add(levelCatalog.allLevels[0]);

        TempPlayer.instance.transform.position = previousLevel.spawnPoint.position;
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
            Debug.LogWarning($"No incomplete levels of type {levelType}, Loading Final Level");
            LoadLevel(levelCatalog.allLevels.Last());
        }
    }

    private void LoadLevel(Level_Scriptable levelData)
    {
        GameObject nextLevelObj = Instantiate(levelData.level);

        activeLevelRefs.Add(nextLevelObj);

        LevelSegments nextLevel = nextLevelObj.GetComponent<LevelSegments>();

        SpawnPoint sp = nextLevel.spawnPoint.gameObject.GetComponent<SpawnPoint>();

        if (previousLevel == null)
        {
            previousLevel = nextLevel;            

            StartCoroutine(sp.WaitForLoad());

            return;
        }             

        StartCoroutine(sp.WaitForLoad());

        AlignLevels(previousLevel, nextLevel);

        previousLevel = nextLevel;

        GameManager.instance.levelLockedIn = false;
    }    

    private void RandomizeLevels()
    {
        HashSet<int> assignedIds = new HashSet<int>();

        foreach (var level in levelCatalog.allLevels)
        {
            int levelId;

            do
            {
                levelId = System.Guid.NewGuid().GetHashCode();
            } while (assignedIds.Contains(levelId));

            level.levelId = levelId;
            assignedIds.Add(levelId);
        }
    }

    private void AlignLevels(LevelSegments from, LevelSegments to)
    {
        Vector3 offset = from.exitPoint.position - to.entryPoint.position;
        to.transform.position += offset;
    }

    public void ResetLevels()
    {
        GameManager.instance.ClearEvents();

        loadedLevels.Clear();
        foreach (var levelRef in activeLevelRefs)
        {
            Debug.Log("Resetting Levels");

            LevelReset levelReset = levelRef.GetComponent<LevelReset>();

            levelReset.ResetObjects();
            if (levelRef != null)
                Destroy(levelRef);
        }
        activeLevelRefs.Clear();

        Destroy(GameObject.Find("FireSprite"));
        Destroy(GameObject.Find("WaterSprite"));
        Destroy(GameObject.Find("AirSprite"));
        Destroy(GameObject.Find("EarthSprite"));
    }
}
