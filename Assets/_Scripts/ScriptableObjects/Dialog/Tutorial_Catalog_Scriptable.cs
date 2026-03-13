using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Tutorial Catalog Scriptable", menuName = "Scriptable Objects/Tutorial_Catalog_Scriptable")]
public class Tutorial_Catalog_Scriptable : ScriptableObject
{
    [Serializable] 
    public class TutorialSteps
    {
        public string speaker;
        [TextArea(3, 6)]        
        public string tutorialText;
        public TutorialTrigger trigger;
        //public AudioClip voiceLine;
    }

    public enum TutorialTrigger
    {
        None,        
        PlayerMove,
        PlayerJump,
        IntroStory,
        RescueSprite,
        PullLever,
        UseSprite     
    }

    

    [CreateAssetMenu(menuName = "Tutorial/ Tutorial Sequence")]
    public class TutorialSequence : ScriptableObject
    {
        public List<TutorialSteps> tutorialSteps;
    }
}
