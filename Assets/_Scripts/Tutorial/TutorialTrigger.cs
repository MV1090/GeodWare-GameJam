using UnityEngine;

public class TutorialTrigger : MonoBehaviour
{   
    public TutorialSequence.TutorialTrigger triggerType;

    private bool hasBeenTriggered = false;

    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(hasBeenTriggered || TutorialManager.instance.tutorialCompleted)
            return;

        if (collision.CompareTag("Player"))
        {
            hasBeenTriggered = true;

            TutorialManager.instance.TriggerEvent(triggerType);
            //TutorialManager.instance.tutorialMenu.gameObject.SetActive(true);
        }               
    }
}
