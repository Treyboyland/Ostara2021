using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathParticleSpawner : MonoBehaviour
{
    [SerializeField]
    GameEventVector onSpawnDeathParticle;

    [SerializeField]
    ParticlePool pool;

    public void SpawnParticle()
    {
        var particle = pool.GetObject();
        particle.transform.position = onSpawnDeathParticle.Value;
        particle.gameObject.SetActive(true);
    }
}
