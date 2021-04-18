using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioStats", menuName = "Audio/Audio Stats")]
public class AudioStats : ScriptableObject
{
    [SerializeField]
    List<AudioClip> clips;

    [SerializeField]
    Vector2 volumeRange;

    [SerializeField]
    Vector2 pitchRange;

    public void SetData(AudioSource source)
    {
        int index = Random.Range(0, clips.Count);
        source.clip = clips[index];
        source.volume = GetVolume();
        source.pitch = GetPitch();
    }

    float GetPitch()
    {
        return Random.Range(pitchRange.x, pitchRange.y);
    }

    float GetVolume()
    {
        return Random.Range(volumeRange.x, volumeRange.y);
    }
}
