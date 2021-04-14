using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GroundStats", menuName = "Ground/Stats")]
public class GroundStats : ScriptableObject
{
    [Tooltip("Range of values at which the ground will be scorched")]
    [SerializeField]
    Vector2 scorchedValue;

    [Tooltip("Range of values at or above which things can grow again")]
    [SerializeField]
    Vector2 growthValue;

    [Tooltip("Color of the earth where things cannot grow")]
    [SerializeField]
    Gradient scorchedColors;

    [Tooltip("Color of the earth when it can grow things")]
    [SerializeField]
    Gradient growthColors;


    public float GetScorchedValue()
    {
        return Random.Range(scorchedValue.x, scorchedValue.y);
    }

    public float GetGrowthValue()
    {
        return Random.Range(growthValue.x, growthValue.y);
    }

    public Color GetScorchedColor()
    {
        return scorchedColors.Evaluate(Random.Range(0.0f, 1.0f));
    }

    public Color GetGrowthColor()
    {
        return growthColors.Evaluate(Random.Range(0.0f, 1.0f));
    }
}
