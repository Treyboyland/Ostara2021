using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TreeStats", menuName = "Ground/Trees Stats")]
public class TreeStats : ScriptableObject
{
    [Tooltip("Color Range for bark")]
    [SerializeField]
    Gradient barkColor;

    [Tooltip("Color Range for leaves")]
    [SerializeField]
    Gradient leavesColor;

    [Tooltip("Alpha Range for leaves")]
    [SerializeField]
    Vector2 leavesAlpha;

    [Tooltip("x,y - width z,w - height")]
    [SerializeField]
    Vector4 treeScale;

    [Tooltip("x,y - width z,w - height")]
    [SerializeField]
    Vector4 leavesScale;

    [Tooltip("Possible sprites for tree tops")]
    [SerializeField]
    List<Sprite> leavesSprites;

    public Vector3 GetBarkScale()
    {
        Vector3 toReturn = new Vector3(0, 0, 1);
        toReturn.x = Random.Range(treeScale.x, treeScale.y);
        toReturn.y = Random.Range(treeScale.z, treeScale.w);

        return toReturn;
    }

    public Vector3 GetLeavesScale()
    {
        Vector3 toreturn = new Vector3(0, 0, 1);
        toreturn.x = Random.Range(leavesScale.x, leavesScale.y);
        toreturn.y = Random.Range(leavesScale.z, leavesScale.w);

        return toreturn;
    }

    public Color GetLeavesColor()
    {
        Color color;
        color = leavesColor.Evaluate(Random.Range(0.0f, 1.0f));
        color.a = GetLeavesAlpha();

        return color;
    }

    float GetLeavesAlpha()
    {
        return Random.Range(leavesAlpha.x, leavesAlpha.y);
    }


    public Color GetBarkColor()
    {
        return barkColor.Evaluate(Random.Range(0.0f, 1.0f));
    }

    public Sprite GetLeavesSprite()
    {
        int index = Random.Range(0, leavesSprites.Count);
        return leavesSprites[index];
    }
}
