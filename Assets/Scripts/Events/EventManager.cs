using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager 
{
    static List<DifficultyMenu> gameStartedInvokers = new List<DifficultyMenu>();
    static List<UnityAction<Difficulty>> gameStartedListeners = new List<UnityAction<Difficulty>>();

    /// <summary>
    /// adds the script as a game started invoker
    /// </summary>
    /// <param name="invoker"></param>
    public static void AddGameStartedInvoker(DifficultyMenu invoker)
    {
        gameStartedInvokers.Add(invoker);
        foreach (UnityAction<Difficulty> listener in gameStartedListeners)
        {
            invoker.AddGameStartedListener(listener);
        }
    }

    /// <summary>
    /// Adds method as a game started listener
    /// </summary>
    /// <param name="listener"></param>
    public static void AddGameStartedListener(UnityAction<Difficulty> listener)
    {
        gameStartedListeners.Add(listener);
        foreach (DifficultyMenu invoker in gameStartedInvokers)
        {
            invoker.AddGameStartedListener(listener);
        }
    }
}
