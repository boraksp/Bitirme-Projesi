using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class MenuManager 
{   
    public static void GoToMenu(MenuName menu)
    {
        switch (menu)
        {
            case MenuName.Difficulty:
                //go to DifficultyMenu
                SceneManager.LoadScene("DifficultyMenu");
                break;
            case MenuName.Help:
                //go to Help Menu
                SceneManager.LoadScene("HelpMenu");
                break;
            case MenuName.Main:
                // go to Main Menu
                SceneManager.LoadScene("MainMenu");
                break;
            case MenuName.Pause:
                //Instantiate prefab
                Object.Instantiate(Resources.Load("PauseMenu"));
                break;
        }
    }
    
}
