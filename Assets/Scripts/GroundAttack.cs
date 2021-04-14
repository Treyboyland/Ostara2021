using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundAttack : MonoBehaviour
{
    [SerializeField]
    float damagePerSecond;

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.LogWarning(gameObject.name + " trigger");
        var ground = other.gameObject.GetComponent<Ground>();
        if (ground == null)
        {
            return;
        }
        ground.CurrentGrowth -= damagePerSecond * Time.deltaTime;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        var ground = other.gameObject.GetComponent<Ground>();
        if (ground == null)
        {
            return;
        }
        ground.CurrentGrowth -= damagePerSecond * Time.deltaTime;
    }

}
