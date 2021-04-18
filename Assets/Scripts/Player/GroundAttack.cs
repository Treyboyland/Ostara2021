using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundAttack : MonoBehaviour
{
    [SerializeField]
    float damagePerSecond;

    public float DamagePerSecond
    {
        get
        {
            return damagePerSecond;
        }
    }

    [SerializeField]
    AttackType currentType;

    public AttackType AttackType
    {
        get
        {
            return currentType;
        }
    }

    [SerializeField]
    AttackType healType;

    [SerializeField]
    AttackType damageType;

    private void OnTriggerEnter2D(Collider2D other)
    {
        CheckForDamage(other);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        CheckForDamage(other);
    }

    void CheckForDamage(Collider2D other)
    {
        var ground = other.gameObject.GetComponent<Ground>();
        if (ground == null)
        {
            return;
        }
        ground.CurrentGrowth = ground.CurrentGrowth + (currentType == damageType ? -1 : 1) * damagePerSecond * Time.deltaTime;
    }

}
