using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class DifficultyMenu : MonoBehaviour
{
    GameStartedEvent gameStartedEvent = new GameStartedEvent();

    void Start()
    {
        // add invoker to event manager
        EventManager.AddGameStartedInvoker(this);
    }

    /// <summary>
    /// Adds the given listener for the game started event
    /// </summary>
    /// <param name="listener"></param>
    public void AddGameStartedListener(UnityAction<Difficulty> listener)
    {
        gameStartedEvent.AddListener(listener);
    }

    /// <summary>
    /// Starts an easy game
    /// </summary>
    public void StartEasyGame()
    {
        gameStartedEvent.Invoke(Difficulty.Easy);
    }

    /// <summary>
    /// Starts an medium game
    /// </summary>
    public void StartMediumGame()
    {
        gameStartedEvent.Invoke(Difficulty.Medium);
    }

    public void StartHardGame()
    {
        gameStartedEvent.Invoke(Difficulty.Hard);
    }
}
