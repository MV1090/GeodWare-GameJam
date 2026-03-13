using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class PauseMenu : BaseMenu
{
    private EventInstance pauseSnapshot;

    void Awake()
    {
        pauseSnapshot = RuntimeManager.CreateInstance("snapshot:/Pause Menu");
    }

    override public void EnterState()
    {
        base.EnterState();

        Time.timeScale = 0f;

        pauseSnapshot.start();
    }

    override public void ExitState()
    {
        base.ExitState();

        Time.timeScale = 1f;

        pauseSnapshot.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);

        TempPlayer.instance.isPauseMenuOpen = false;
    }

    public void JumpToMainMenu()
    {
        context.SetActiveMenu(MenuManager.MenuType.MainMenu);
    }
}
