using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTreeSpawner : MonoBehaviour
{
    [SerializeField]
    Ground ground;

    [SerializeField]
    TreeSpawnStats stats;

    List<Tree> trees = new List<Tree>();

    int maxTrees;

    float elapsed = 0;

    float timeOfNextCheck = 0;

    static TreePool pool;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (ground.CanGrowStuff)
        {
            elapsed += Time.deltaTime;
            CheckSpawn();
        }
        else
        {
            elapsed = 0;
        }
    }

    private void OnEnable()
    {
        maxTrees = stats.GetMaxTrees();
        timeOfNextCheck = stats.GetTimeForNextSpawnCheck();
        InitialSpawn();
    }

    void CheckSpawn()
    {
        if (trees.Count >= maxTrees)
        {
            return;
        }

        if (elapsed < timeOfNextCheck)
        {
            return;
        }

        elapsed = 0;

        if (Random.value <= stats.TreeSpawnChance)
        {
            SpawnTree();
            timeOfNextCheck = stats.GetTimeForNextSpawnCheck();
        }
    }

    void FindPool()
    {
        if (pool != null)
        {
            return;
        }

        pool = FindObjectOfType<TreePool>();
    }

    void RemoveTree(Tree tree)
    {
        trees.Remove(tree);
        tree.OnTreeDestroyed.RemoveListener(RemoveTree);
    }

    void SpawnTree()
    {
        FindPool();
        if (pool == null)
        {
            return;
        }

        var tree = pool.GetObject();
        tree.gameObject.SetActive(true);
        tree.CreateTree(transform.position + new Vector3(stats.GetXOffset(), 0, stats.GetZOffSet()));
    }

    void InitialSpawn()
    {
        maxTrees = stats.GetMaxTrees();
        for (int i = 0; i < maxTrees; i++)
        {
            if (Random.value > stats.TreeSpawnChance * (i == 0 ? 2 : 1))
            {
                break;
            }
            SpawnTree();
        }
    }
}
