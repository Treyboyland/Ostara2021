using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserColor : MonoBehaviour
{
    [SerializeField]
    Gradient gradient;

    [SerializeField]
    float secondsPerLoop;

    [SerializeField]
    List<SpriteRenderer> lasers;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChangeLaserColors());
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SetColor(SpriteRenderer renderer, Color color)
    {
        color.a = renderer.color.a;
        renderer.color = color;
    }

    IEnumerator ChangeLaserColors()
    {
        float elapsed = 0;
        while (true)
        {
            elapsed = (elapsed + Time.deltaTime) % secondsPerLoop;
            foreach (var laser in lasers)
            {
                SetColor(laser, gradient.Evaluate(elapsed / secondsPerLoop));
            }
            yield return null;
        }
    }
}
