using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSeedFire : MonoBehaviour
{
    [SerializeField]
    PigHead player;

    [SerializeField]
    Camera mainCamera;

    [SerializeField]
    GameEventVector OnWorldSeedFired;

    [SerializeField]
    float secondsBetweenFiring;

    float elapsed = 0;

    // Start is called before the first frame update
    void Start()
    {
        elapsed = secondsBetweenFiring;
    }

    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;
        if (player.IsInCreationMode && elapsed >= secondsBetweenFiring && Input.GetButton("Fire"))
        {
            elapsed = 0;
            FireSeed();
        }
    }


    void FireSeed()
    {
        var pos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;

        OnWorldSeedFired.Value = pos;
        OnWorldSeedFired.Invoke();
    }
}
