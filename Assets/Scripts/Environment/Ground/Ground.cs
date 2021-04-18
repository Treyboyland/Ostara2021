using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer spriteRenderer;

    [SerializeField]
    GroundStats stats;

    Color scorchedColor;

    Color growthColor;

    struct ScorchValues
    {
        public float ScortchCutoff;
        public float GrowthCutoff;
    }

    ScorchValues growthValues = new ScorchValues();

    float currentGrowth = 0;

    public float CurrentGrowth
    {
        get
        {
            return currentGrowth;
        }
        set
        {
            currentGrowth = value;
            currentGrowth = Mathf.Max(Mathf.Min(growthValues.GrowthCutoff, currentGrowth), stats.MinGrowth);
            UpdateSprite();
        }
    }

    public float GrowthNormalized
    {
        get
        {
            return (currentGrowth - growthValues.ScortchCutoff) / (growthValues.GrowthCutoff - growthValues.ScortchCutoff);
        }
    }

    public bool CanGrowStuff
    {
        get
        {
            return currentGrowth >= growthValues.GrowthCutoff;
        }
    }


    private void OnEnable()
    {
        SetStartingParameters();
        CurrentGrowth = growthValues.GrowthCutoff;
    }

    void SetStartingParameters()
    {
        scorchedColor = stats.GetScorchedColor();
        growthColor = stats.GetGrowthColor();
        growthValues.GrowthCutoff = stats.GetGrowthValue();
        growthValues.ScortchCutoff = stats.GetScorchedValue();
    }

    void UpdateSprite()
    {
        spriteRenderer.color = Color.Lerp(scorchedColor, growthColor,
            (currentGrowth - growthValues.ScortchCutoff) / (growthValues.GrowthCutoff - growthValues.ScortchCutoff));
    }
}
