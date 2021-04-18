using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TreeLeaves : Destructible
{
    [SerializeField]
    SpriteRenderer spriteRenderer;

    public void SetColor(Color c)
    {
        spriteRenderer.color = c;
    }

    public void SetLocalPosition(Vector3 pos)
    {
        transform.localPosition = pos;
    }

    public void SetScale(Vector3 scale)
    {
        transform.localScale = scale;
    }

    public void SetSprite(Sprite sp)
    {
        spriteRenderer.sprite = sp;
    }
}
