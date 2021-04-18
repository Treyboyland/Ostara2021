using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadOnQuit : MonoBehaviour
{
    [SerializeField]
    SceneLoader loader;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Quit"))
        {
            loader.LoadScene();
        }
    }
}
