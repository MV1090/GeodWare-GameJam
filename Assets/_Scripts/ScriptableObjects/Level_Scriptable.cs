using UnityEngine;

[CreateAssetMenu(fileName = "Level_Scriptable", menuName = "Scriptable Level Objects/Level_Scriptable")]
public class Level_Scriptable : ScriptableObject
{
    //public enum LevelType
    //{
    //    Earth,
    //    Fire,
    //    Water,
    //    Air
    //}

    public string levelType;
    public int levelId;    

    public GameObject level;



    
}


