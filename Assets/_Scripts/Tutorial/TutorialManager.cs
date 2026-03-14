using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public static TutorialManager instance { get; private set; }

    public TutorialSequence tutorialSequence;

    private int currentStepIndex = 0;

    [SerializeField] TMP_Text speakerText;
    [SerializeField] TMP_Text tutorialText;
    [SerializeField] Image speakerImage;

    public TutorialMenu tutorialMenu;

    public bool tutorialMenuOpen = false;

    public bool tutorialCompleted = false;  

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }

    void Start()
    {
        //RunStep();
    }

    public void RunStep()
    {
        if (currentStepIndex >= tutorialSequence.tutorialSteps.Count)
        {
            Debug.Log("Tutorial Completed");
            return;
        }

        var step = tutorialSequence.tutorialSteps[currentStepIndex];

        speakerText.text = step.speaker;
        tutorialText.text = step.tutorialText;
        speakerImage.sprite = step.speakerSprite;

        //if (step.trigger == TutorialSequence.TutorialTrigger.None)
        //{
        //    NextStep();
        //}
    }

    public void TriggerEvent(TutorialSequence.TutorialTrigger tutorialTrigger)
    {
        if (currentStepIndex >= tutorialSequence.tutorialSteps.Count)
        {
            tutorialCompleted = true;
            return;
        }

        var step = tutorialSequence.tutorialSteps[currentStepIndex];

        if (step.trigger == tutorialTrigger)
        {
            tutorialMenu.gameObject.SetActive(true);
            RunStep();
        }
    }

    public void AdvanceTutorial()
    {
        if (currentStepIndex + 1 >= tutorialSequence.tutorialSteps.Count)
        {
            tutorialMenu.gameObject.SetActive(false);
            tutorialCompleted = true;
            return;
        }

        var currentStep = tutorialSequence.tutorialSteps[currentStepIndex];
        var nextStep = tutorialSequence.tutorialSteps[currentStepIndex + 1];

        if (currentStep.trigger == nextStep.trigger)
        {
            currentStepIndex++;
            RunStep();
        }
        else
        {
            currentStepIndex++;
            tutorialMenu.gameObject.SetActive(false);
        }
    }

    public int GetCurrentStepIndex()
    {
        return currentStepIndex;
    }

    void NextStep()
    {        
        RunStep();        
    }
}