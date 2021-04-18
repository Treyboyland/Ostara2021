using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class QuitScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Quit"))
        {
#if UNITY_EDITOR
            EditorApplication.Beep();
            //EditorApplication.isPlaying = false;
#elif UNITY_WEBGL
            //Do Nothing
#else 
       Application.Quit();
#endif
        }
    }
}
