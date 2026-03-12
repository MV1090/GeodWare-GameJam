using UnityEngine;

public class MainMenu : BaseMenu
{
    override public void EnterState()
    {
        base.EnterState();
        Time.timeScale = 0f;
    }

    override public void ExitState()
    {
        base.ExitState();
    }

    public void JumpToGameMenu()
    {
        // Change FMOD music state from Menu → Game
        AudioManager.Instance.SetMusicState(1f);

         // Start ambience when game begins
    AudioManager.Instance.StartAmbience();

        context.SetActiveMenu(MenuManager.MenuType.GameUI);
    }
}
