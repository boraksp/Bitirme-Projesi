using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{   
    // Update is called once per frame
    void Update()
    {
        // pause game on escape key if game isnt currently paused
        if (Input.GetKeyUp(KeyCode.Escape) && Time.timeScale != 0)
        {
            MenuManager.GoToMenu(MenuName.Pause);
        }
    }
}
