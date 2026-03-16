using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalLevel : MonoBehaviour, IResettable
{
    [SerializeField] GameObject[] sprites;
    [SerializeField] PodiumScript[] podiums;
    [SerializeField] List<bool> activatedPodiums = new List<bool>();   

    private void Awake()
    {
        podiums = GetComponentsInChildren<PodiumScript>();

        foreach (PodiumScript podium in podiums)
        {
            if (podium == null)
            {
                Debug.LogError("Podium reference missing!");
                continue;
            }

            podium.OnActivated += CheckFountainActivation;

        }
    }

    public void SaveState()
    {
        
    }

    public void ResetState()
    {
        activatedPodiums.Clear();
    }

    void Start()
    {
        CheckLastLevelSprite();      

    }

    void CheckFountainActivation(bool activated)
    {
        if (activated)
        {
            activatedPodiums.Add(true);
            CheckWinCondition();
        }
    }

    void CheckWinCondition()
    {
        if(activatedPodiums.Count == podiums.Length)
        {
            Debug.Log("Win condition met!");
            StartCoroutine(WaitAtEndGame());
        }
    }

    IEnumerator WaitAtEndGame()
    {
        yield return new WaitForSeconds(1f);
        GameManager.instance.gameCompleted = true;
        MenuManager.instance.SetActiveMenu(MenuManager.MenuType.EndGame);
    }

    void CheckLastLevelSprite() 
    {
        switch (GameManager.instance.pendingLevelElement)
        {
            case (RescuedSprites.ElementSprite.Air):
                sprites[0].SetActive(false);
                break;
            case (RescuedSprites.ElementSprite.Earth):
                sprites[1].SetActive(false);
                break;
            case (RescuedSprites.ElementSprite.Fire):
                sprites[2].SetActive(false);
                break;
            case (RescuedSprites.ElementSprite.Water):
                sprites[3].SetActive(false);
                break;
        }
    }


}
