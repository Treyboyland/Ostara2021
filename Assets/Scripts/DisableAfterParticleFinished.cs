using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAfterParticleFinished : MonoBehaviour
{
    [SerializeField]
    ParticleSystem particles;


    private void OnEnable()
    {
        if (gameObject.activeInHierarchy)
        {
            StartCoroutine(Wait());
        }
    }


    IEnumerator Wait()
    {
        while (particles.IsAlive(true))
        {
            yield return null;
        }

        gameObject.SetActive(false);
    }
}
