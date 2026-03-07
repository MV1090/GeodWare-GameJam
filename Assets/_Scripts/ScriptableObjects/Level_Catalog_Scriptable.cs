using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Level Catalog", menuName = "Scriptable Level Objects/Level_catalog")]
public class Level_Catalog_Scriptable : ScriptableObject
{
    public List<Level_Scriptable> allLevels = new List<Level_Scriptable>();

}
