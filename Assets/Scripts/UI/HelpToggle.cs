using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpToggle : MonoBehaviour
{
    [SerializeField]
    GameObject instructions;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Help"))
        {
            instructions.SetActive(!instructions.activeInHierarchy);
        }
    }
}
