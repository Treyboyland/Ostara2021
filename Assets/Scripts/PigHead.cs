using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigHead : MonoBehaviour
{
    [SerializeField]
    GameEvent onDestructionMode;

    [SerializeField]
    GameEvent onCreationMode;

    [SerializeField]
    bool isInCreationMode;

    public bool IsInCreationMode
    {
        get
        {
            return isInCreationMode;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeCorrectEvent();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("ToggleMode"))
        {
            isInCreationMode = !isInCreationMode;
            InvokeCorrectEvent();
        }
    }

    void InvokeCorrectEvent()
    {
        if (isInCreationMode)
        {
            onCreationMode.Invoke();
        }
        else
        {
            onDestructionMode.Invoke();
        }
    }
}
