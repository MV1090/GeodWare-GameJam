using UnityEngine;

public class PauseMenu : BaseMenu
{
    override public void EnterState()
    {
        base.EnterState();
        Time.timeScale = 0f; // Ensure the game is running when entering the MainMenu
    }

    override public void ExitState()
    {
        base.ExitState();
        Time.timeScale = 1f; // Ensure the game is running when exiting the PauseMenu
    }

    public void JumpToMainMenu()
    {
        context.SetActiveMenu(MenuManager.MenuType.MainMenu);
    }
}
