using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTracker : MonoBehaviour
{
    [SerializeField]
    Transform toTrack;

    [SerializeField]
    Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        if (toTrack != null)
        {
            transform.position = toTrack.position + offset;
        }
    }
}
