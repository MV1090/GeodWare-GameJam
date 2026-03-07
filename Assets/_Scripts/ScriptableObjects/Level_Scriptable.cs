using UnityEngine;

[CreateAssetMenu(fileName = "Level_Scriptable", menuName = "Scriptable Level Objects/Level_Scriptable")]
public class Level_Scriptable : ScriptableObject
{
    public string levelName;
    public int levelId;
    public bool isCompleted;

    public GameObject level;

    
}


