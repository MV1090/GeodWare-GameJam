using UnityEngine;

public class GameUI : BaseMenu
{
    override public void EnterState()
    {
        base.EnterState();
        Time.timeScale = 1f; // Ensure the game is running when entering the GameUI
    }

    override public void ExitState()
    {
        base.ExitState();
        // No need to change time scale here, as it should be handled by the specific menus that pause the game (like PauseMenu or EndGameMenu)
    }
}
