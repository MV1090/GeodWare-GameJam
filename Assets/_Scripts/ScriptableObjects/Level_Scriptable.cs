using UnityEngine;

[CreateAssetMenu(fileName = "Level_Scriptable", menuName = "Scriptable Level Objects/Level_Scriptable")]
public class Level_Scriptable : ScriptableObject
{   
    public string levelType;
    public int levelId;    

    public GameObject level;
    
}


