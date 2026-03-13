using UnityEngine;

public class LevelLoadDecider : MonoBehaviour
{
    public bool hasTriggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
            return;
        if (hasTriggered)
            return;

        AudioManager.Instance.SetMusicParameter("level loaded", 1f);

        hasTriggered = true;

        switch (GameManager.instance.pendingLevelElement)
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
