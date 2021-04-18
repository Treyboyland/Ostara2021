using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizedAudio : MonoBehaviour
{
    [SerializeField]
    AudioStats stats;

    [SerializeField]
    AudioSource source;

    private void OnEnable()
    {
        if (gameObject.activeInHierarchy)
        {
            StartCoroutine(PlayRandomAudioThenDisable());
        }
    }


    IEnumerator PlayRandomAudioThenDisable()
    {
        stats.SetData(source);
        source.Play();
        while (source.isPlaying)
        {
            yield return null;
        }
        gameObject.SetActive(false);
    }
}
