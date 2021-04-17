using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventGeneric<T> : GameEvent
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

    List<GameEventGenericListener<T>> genericListeners = new List<GameEventGenericListener<T>>();

    public void AddListener(GameEventGenericListener<T> toAdd)
    {
        if (!genericListeners.Contains(toAdd))
        {
            genericListeners.Add(toAdd);
        }
    }

    public void RemoveListener(GameEventGenericListener<T> toRemove)
    {
        genericListeners.Remove(toRemove);
    }

    public override void Invoke()
    {
        foreach (var listener in genericListeners)
        {
            listener.Response.Invoke(value);
        }

        foreach (var listener in listeners)
        {
            listener.Response.Invoke();
        }
    }
}
