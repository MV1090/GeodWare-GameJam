using UnityEngine;
using System.Collections.Generic;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance { get; private set; }

    public BaseMenu[] allMenus;
    public enum MenuType
    {
        MainMenu,
        GameUI,
        SettingsMenu,
        EndGame,
        PauseMenu
    }

    private BaseMenu currentMenu;
    private Dictionary<MenuType, BaseMenu> menuDictionary = new Dictionary<MenuType, BaseMenu>();
    private Stack<BaseMenu> menuStack = new Stack<BaseMenu>();

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

    }

    private void Start()
    {
        if(allMenus == null || allMenus.Length == 0)
        {
            Debug.LogError("No menus assigned to MenuManager.");
            return;
        }

        foreach (BaseMenu menu in allMenus) 
        {
            if (menu == null) continue;

            menu.InitState(this);

            if (menuDictionary.ContainsKey(menu.type))
            {
                Debug.LogWarning($"Duplicate menu type {menu.type} found. Skipping.");
                continue;
            }

            menuDictionary.Add(menu.type, menu);
        }

        foreach(MenuType type in menuDictionary.Keys)
        {
            menuDictionary[type].gameObject.SetActive(false);
        }
        
        SetActiveMenu(MenuType.MainMenu);
    }

    public void SetActiveMenu(MenuType newType, bool isJumpingBack = false)
    {
        if (!menuDictionary.ContainsKey(newType)) return;

        if (currentMenu != null)
        {
            currentMenu.ExitState();
            currentMenu.gameObject.SetActive(false);
        }

        currentMenu = menuDictionary[newType];
        currentMenu.gameObject.SetActive(true);
        currentMenu.EnterState();

        if (!isJumpingBack)
        {
            menuStack.Push(currentMenu);
        }
    }

    public void JumpBack()
    {
        if (menuStack.Count > 1)
        {
            menuStack.Pop();
            BaseMenu previousMenu = menuStack.Peek();
            SetActiveMenu(previousMenu.type, true);
        }
    }
}
