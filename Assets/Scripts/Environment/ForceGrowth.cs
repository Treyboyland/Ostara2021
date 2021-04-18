using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceGrowth : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        var spawn = other.GetComponent<GroundTreeSpawner>();

        if (spawn != null)
        {
            spawn.ForceSpawn();
        }
    }
}
