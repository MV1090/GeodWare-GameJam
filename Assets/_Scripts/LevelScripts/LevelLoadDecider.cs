using UnityEngine;

public class LevelLoadDecider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.gameObject.CompareTag("Player"))
        {
            switch (/*TempPlayer.instance.rescuedSprites.GetCurrentState()*/ GameManager.instance.pendingLevelElement)
            {
                case RescuedSprites.ElementSprite.Earth:
                    LevelManager.instance.LoadNextLevelByType("Earth");
                    break;
                case RescuedSprites.ElementSprite.Fire:
                    LevelManager.instance.LoadNextLevelByType("Fire");
                    break;
                case RescuedSprites.ElementSprite.Water:
                    LevelManager.instance.LoadNextLevelByType("Water");
                    break;
                case RescuedSprites.ElementSprite.Air:
                    LevelManager.instance.LoadNextLevelByType("Air");
                    break;
                case RescuedSprites.ElementSprite.Default:
                    Debug.LogWarning("Player is in Default state. No level will be loaded.");
                    break;
            }
        }
    }
}
