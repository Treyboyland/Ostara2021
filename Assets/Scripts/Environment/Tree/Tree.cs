using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Tree : MonoBehaviour
{
    [SerializeField]
    TreeStats stats;

    [SerializeField]
    TreeBark bark;

    [SerializeField]
    TreeLeaves leaves;

    public TreeDeathEvent OnTreeDestroyed = new TreeDeathEvent();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnEnable()
    {
        leaves.gameObject.SetActive(true);
        bark.gameObject.SetActive(true);
    }

    public void CreateTree(Vector3 pos)
    {
        transform.position = pos;
        bark.SetLocalPosition(new Vector3());
        bark.SetColor(stats.GetBarkColor());
        bark.SetScale(stats.GetBarkScale());

        leaves.SetLocalPosition(new Vector3(0, bark.transform.localScale.y, 0));
        leaves.SetColor(stats.GetLeavesColor());
        leaves.SetScale(stats.GetLeavesScale());
        leaves.SetSprite(stats.GetLeavesSprite());

        leaves.gameObject.SetActive(true);
        bark.gameObject.SetActive(true);
    }

    public void CreateTree()
    {
        CreateTree(transform.position);
    }

    public void Kill()
    {
        gameObject.SetActive(false);
    }
}
