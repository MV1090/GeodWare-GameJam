using UnityEngine;

public class BaseMenu : MonoBehaviour
{
    
    public MenuManager.MenuType type;
    protected MenuManager context;

    public virtual void InitState(MenuManager ctx)
    {
        context = ctx;
    }

    public virtual void EnterState()
    {

    }
    public virtual void ExitState()
    {

    }

    public void JumpBack()
    {
        context.JumpBack();
    }

    public void SetNextMenu(MenuManager.MenuType newState)
    {
        context.SetActiveMenu(newState);
    }

}
