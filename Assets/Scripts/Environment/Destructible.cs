using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Destructible : MonoBehaviour
{
    [SerializeField]
    protected GameEventVector destructionLocation;

    public UnityEvent OnObjectDestroyed;

    public virtual void Awake()
    {
        OnObjectDestroyed.AddListener(() =>
        {
            destructionLocation.Value = transform.position;
            destructionLocation.Invoke();
        });
    }

    public void FireDestructionEvent()
    {
        OnObjectDestroyed.Invoke();
    }
}
