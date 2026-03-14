using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TutorialSequence", menuName = "Tutorial/Tutorial Sequence")]
public class TutorialSequence : ScriptableObject
{
    [Serializable]
    public class TutorialSteps
    {
        public string speaker;
        [TextArea(3, 6)]
        public string tutorialText;
        public TutorialTrigger trigger;
        public Sprite speakerSprite;
    }

    public List<TutorialSteps> tutorialSteps;

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
}
