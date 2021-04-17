using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TreeSpawnStats", menuName = "Ground/Tree Spawn Stats")]
public class TreeSpawnStats : ScriptableObject
{
    [Tooltip("Max amount of trees per block")]
    [SerializeField]
    Vector2Int maxTrees;

    [Tooltip("Distance from center the tree can be")]
    [SerializeField]
    Vector2 xOffset;

    [Tooltip("Seconds between spawn checks")]
    [SerializeField]
    Vector2 spawnCheck;

    [Range(0, 1)]
    [Tooltip("Odds that the ground will spawn a tree")]
    [SerializeField]
    float treeSpawnChance;

    /// <summary>
    /// Odds that the ground will spawn a tree
    /// </summary>
    /// <value></value>
    public float TreeSpawnChance
    {
        get
        {
            return treeSpawnChance;
        }
    }

    public float GetXOffset()
    {
        return Random.Range(xOffset.x, xOffset.y);
    }

    public int GetMaxTrees()
    {
        return Random.Range(maxTrees.x, maxTrees.y);
    }

    public float GetTimeForNextSpawnCheck()
    {
        return Random.Range(spawnCheck.x, spawnCheck.y);
    }
}
