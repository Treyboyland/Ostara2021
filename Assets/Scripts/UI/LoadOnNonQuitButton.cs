using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadOnNonQuitButton : MonoBehaviour
{
    [SerializeField]
    SceneLoader loader;


    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && !Input.GetButton("Quit"))
        {
            loader.LoadScene();
        }
    }
}
