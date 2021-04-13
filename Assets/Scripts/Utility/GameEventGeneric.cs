using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventGeneric<T> : ScriptableObject
{
    [Tooltip("Value that will be sent whenever the game event is invoked")]
    [SerializeField]
    T value;

    /// <summary>
    /// Value that will be sent whenever the game event is invoked
    /// </summary>
    /// <value></value>
    public T Value
    {
        get
        {
            return value;
        }
        set
        {
            this.value = value;
        }
    }

    List<GameEventGenericListener<T>> listeners = new List<GameEventGenericListener<T>>();

    public void AddListener(GameEventGenericListener<T> toAdd)
    {
        if (!listeners.Contains(toAdd))
        {
            listeners.Add(toAdd);
        }
    }

    public void RemoveListener(GameEventGenericListener<T> toRemove)
    {
        listeners.Remove(toRemove);
    }

    public void Invoke()
    {
        foreach (var listener in listeners)
        {
            listener.Response.Invoke(value);
        }
    }
}
