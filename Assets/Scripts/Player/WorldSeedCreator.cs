using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSeedCreator : MonoBehaviour
{
    [SerializeField]
    GameEventVector onFireSeed;

    [SerializeField]
    LaserPool pool;

    public void CreateSeed()
    {
        var seed = pool.GetObject();
        seed.transform.position = onFireSeed.Value;
        seed.gameObject.SetActive(true);
    }
}
