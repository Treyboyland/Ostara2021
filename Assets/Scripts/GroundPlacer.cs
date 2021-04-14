using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPlacer : MonoBehaviour
{
    [SerializeField]
    int numBlocks;

    [SerializeField]
    GroundPool pool;

    // Start is called before the first frame update
    void Start()
    {
        CreateGround();
    }


    public void CreateGround()
    {
        //Note: Assumes unit width
        int leftStart = -numBlocks / 2;
        for (int i = 0; i < numBlocks; i++)
        {
            var ground = pool.GetObject();
            ground.transform.SetParent(transform);
            ground.transform.localPosition = new Vector3(leftStart + 1 * i, 0, 0);
            ground.gameObject.SetActive(true);
        }
    }
}
