using UnityEngine;

public class MainMenu : BaseMenu
{
    override public void EnterState()
    {
        base.EnterState();
        Time.timeScale = 0f; // Ensure the game is running when entering the MainMenu
    }

    override public void ExitState()
    {
        base.ExitState();
        // No need to change time scale here, as it should be handled by the specific menus that pause the game (like PauseMenu or EndGameMenu)
    }

    public void JumpToGameMenu()
    {
        context.SetActiveMenu(MenuManager.MenuType.GameUI);
    }

    public void OnApplicationQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

}
