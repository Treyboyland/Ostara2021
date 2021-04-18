using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAudioPlayer : MonoBehaviour
{
    [SerializeField]
    AudioPool pool;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayAudio()
    {
        var audio = pool.GetObject();
        if (audio != null)
        {
            audio.gameObject.SetActive(true);
        }
    }
}
