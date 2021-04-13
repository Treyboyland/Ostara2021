using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameEvent", menuName = "Events/Normal Event", order = -1)]
public class GameEvent : ScriptableObject
{
    List<GameEventListener> listeners = new List<GameEventListener>();

    public void AddListener(GameEventListener toAdd)
    {
        if (!listeners.Contains(toAdd))
        {
            listeners.Add(toAdd);
        }
    }

    public void RemoveListener(GameEventListener toRemove)
    {
        listeners.Remove(toRemove);
    }

    public void Invoke()
    {
        foreach (var listener in listeners)
        {
            listener.Response.Invoke();
        }
    }
}
