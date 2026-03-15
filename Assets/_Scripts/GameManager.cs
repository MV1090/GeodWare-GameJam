using System;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    static public GameManager instance;

    SpawnPoint currentSpawnPoint;

    public RescuedSprites.ElementSprite pendingLevelElement = RescuedSprites.ElementSprite.Default;

    public event Action<RescuedSprites.ElementSprite> OnStateChanged;

    public bool levelLockedIn;

    public List<GameObject> activeLevelRef;

    public bool gameCompleted;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ClearEvents()
    {
        OnStateChanged = null;
    }
    public void RegisterPlayer(RescuedSprites rescuedSprites)
    {
        rescuedSprites.OnStateChanged += SetNextLevelElement;
    }    

    public void SetNextLevelElement(RescuedSprites.ElementSprite element)
    {
        if (levelLockedIn) return;

        if (element == RescuedSprites.ElementSprite.Default) return;

        pendingLevelElement = element;
        levelLockedIn = true;

        Debug.Log("Next level locked to: " + element);

        OnStateChanged?.Invoke(pendingLevelElement);
    }

    public RescuedSprites.ElementSprite GetNextLevelElement()
    {
        return pendingLevelElement;
    }

    public void ClearNextLevel()
    {
        pendingLevelElement = RescuedSprites.ElementSprite.Default;
        levelLockedIn = false;

        OnStateChanged?.Invoke(pendingLevelElement);
    }

    public void SetCurrentSpawnPoint(SpawnPoint spawnPoint)
    {
        currentSpawnPoint = spawnPoint;
    } 

    public SpawnPoint GetCurrentSpawnPoint()
    {
        return currentSpawnPoint;
    }

    public int GetSpawnPointID()
    {
        if(currentSpawnPoint == null)
            return -1;

        return currentSpawnPoint.spawnPointID;
    }
}
