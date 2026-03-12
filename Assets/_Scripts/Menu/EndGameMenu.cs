using UnityEngine;

public class EndGameMenu : BaseMenu
{
    override public void EnterState()
    {
        base.EnterState();
        Time.timeScale = 0f; // Pause the game
    }

    override public void ExitState()
    {
        base.ExitState();
        Time.timeScale = 1f; // Resume the game
    }   
}
