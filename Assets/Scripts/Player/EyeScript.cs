using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeScript : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer eyeSprite;

    [SerializeField]
    SpriteRenderer diamondSprite;


    public void ShowEyes()
    {
        SetSpriteAlpha(eyeSprite, 1);
        SetSpriteAlpha(diamondSprite, 0);
    }

    public void ShowDiamonds()
    {
        SetSpriteAlpha(diamondSprite, 1);
        SetSpriteAlpha(eyeSprite, 0);
    }

    void SetSpriteAlpha(SpriteRenderer renderer, float alpha)
    {
        var color = renderer.color;
        color.a = alpha;
        renderer.color = color;
    }
}
