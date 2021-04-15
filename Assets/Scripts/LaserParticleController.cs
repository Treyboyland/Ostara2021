using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserParticleController : MonoBehaviour
{
    [SerializeField]
    Camera mainCamera;

    [SerializeField]
    ParticleSystem system;

    bool track = false;

    // Update is called once per frame
    void Update()
    {
        TrackMouse();
    }

    public void PlayParticles()
    {
        system.Play();
        track = true;
    }

    public void StopParticles()
    {
        system.Stop();
        track = false;
    }

    void TrackMouse()
    {
        var pos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        transform.position = pos;
    }
}
