using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndGameMenu : BaseMenu
{
    public TutorialSequence endGameSequence;
    private int currentStepIndex = 0;

    [SerializeField] TMP_Text speakerText;
    [SerializeField] TMP_Text tutorialText;   
    [SerializeField] Button returnToMainMenu;
    [SerializeField] GameObject dialogBox;


    [SerializeField] CameraShake mainCamera;

    override public void EnterState()
    {        
        base.EnterState();
        RunStep();
        Time.timeScale = 0f;
        returnToMainMenu.gameObject.SetActive(false);
    }

    override public void ExitState()
    {
        base.ExitState();
        Time.timeScale = 1f;
    }

    public void AdvanceTutorial()
    {
        if (currentStepIndex + 1 >= endGameSequence.tutorialSteps.Count)
        {
            returnToMainMenu.gameObject.SetActive(true);
            return;
        }

        var currentStep = endGameSequence.tutorialSteps[currentStepIndex];
        var nextStep = endGameSequence.tutorialSteps[currentStepIndex + 1];

        if (currentStep.trigger == nextStep.trigger)
        {
            currentStepIndex++;
            RunStep();
        }
        else
        {
            currentStepIndex++;            
        }
    }

    void Update()
    {      

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentStepIndex >= endGameSequence.tutorialSteps.Count)
            {
                Debug.Log("Tutorial Completed");
                return;
            }

            if(currentStepIndex == 0)
            {
                StartTransformation();
                return;
            }

            AdvanceTutorial();
        }
    }

    private void StartTransformation()
    {
        dialogBox.SetActive(false);
        StartCoroutine(mainCamera.Shake(2f, 0.5f, OnShakeFinished));
    }
    void OnShakeFinished()
    {
        TempPlayer.instance.SetPlayerSpriteToEvilWizard();
        dialogBox.SetActive(true);
        AdvanceTutorial();
    }
    public void RunStep()
    {
        if (currentStepIndex >= endGameSequence.tutorialSteps.Count)
        {                      
            return;
        }

        var step = endGameSequence.tutorialSteps[currentStepIndex];

        speakerText.text = step.speaker;
        tutorialText.text = step.tutorialText; 
        

    }

    public void JumpToMainMenu()
    {        
        currentStepIndex = 0;
        GameManager.instance.gameCompleted = false;
        LevelManager.instance.ResetLevels();
        context.SetActiveMenu(MenuManager.MenuType.MainMenu);
    }
}
