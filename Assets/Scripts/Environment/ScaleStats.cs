using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScaleStats", menuName = "Animation/Scale Stats")]
public class ScaleStats : ScriptableObject
{
    [Tooltip("Max scale reached before coming back down")]
    [SerializeField]
    Vector2 maxScaleRange;

    [Tooltip("Seconds for appearance animation")]
    [SerializeField]
    Vector2 animationSecondsRange;


    public float GetMaxScale()
    {
        return Random.Range(maxScaleRange.x, maxScaleRange.y);
    }

    public float GetAnimationTime()
    {
        return Random.Range(animationSecondsRange.x, animationSecondsRange.y);
    }
}
