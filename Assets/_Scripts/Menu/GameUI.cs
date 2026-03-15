using UnityEngine;

public class GameUI : BaseMenu
{
    override public void EnterState()
    {
        base.EnterState();
        GameManager.instance.gameCompleted = false;
        Time.timeScale = 1f;
    }

    override public void ExitState()
    {
        base.ExitState();        
    }
}
