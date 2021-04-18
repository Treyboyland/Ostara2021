using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TreeBark : Destructible
{
    [SerializeField]
    SpriteRenderer spriteRenderer;

    float midY = 0;

    public override void Awake()
    {
        OnObjectDestroyed.AddListener(() =>
        {
            destructionLocation.Value = transform.position + new Vector3(0, midY, 0);
            destructionLocation.Invoke();
        });
    }

    public void SetColor(Color c)
    {
        spriteRenderer.color = c;
    }

    public void SetScale(Vector3 scale)
    {
        transform.localScale = scale;
        midY = scale.y / 2;
    }

    public void SetLocalPosition(Vector3 pos)
    {
        transform.localPosition = pos;
    }
}
