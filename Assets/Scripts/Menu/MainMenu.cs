using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void GoToDiffucultyMenu()
    {
        MenuManager.GoToMenu(MenuName.Difficulty);
    }

    public void ShowHelp()
    {
        MenuManager.GoToMenu(MenuName.Help);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
