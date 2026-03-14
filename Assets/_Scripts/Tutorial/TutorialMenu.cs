using UnityEngine;

public class TutorialMenu : MonoBehaviour
{
    private void OnEnable()
    {
        
        TutorialManager.instance.tutorialMenuOpen = true;
        
    }
    private void OnDisable()
    {
        
        TutorialManager.instance.tutorialMenuOpen = false;
    }

    private void CheckToClose()
    {
        int index = TutorialManager.instance.GetCurrentStepIndex();
        var sequence = TutorialManager.instance.tutorialSequence;

        if (index + 1 >= sequence.tutorialSteps.Count)
        {
            gameObject.SetActive(false);
            return;
        }

        if (sequence.tutorialSteps[index].trigger ==
            sequence.tutorialSteps[index + 1].trigger)
        {
            TutorialManager.instance.TriggerEvent(sequence.tutorialSteps[index].trigger);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (!TutorialManager.instance.tutorialMenuOpen)
            return;

        if (Input.GetKeyDown(KeyCode.E))
        {
           TutorialManager.instance.AdvanceTutorial();
        }
    }
}
