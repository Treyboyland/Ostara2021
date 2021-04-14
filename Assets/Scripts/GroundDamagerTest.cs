using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDamagerTest : MonoBehaviour
{
    [SerializeField]
    Ground ground;

    [SerializeField]
    bool damage;

    [SerializeField]
    float secondsBetweenDamage;

    float elapsed = 0;

    private void Update()
    {
        elapsed += Time.deltaTime;
        if (damage && elapsed >= secondsBetweenDamage)
        {
            elapsed = 0;
            ground.CurrentGrowth--;
        }
    }
}
