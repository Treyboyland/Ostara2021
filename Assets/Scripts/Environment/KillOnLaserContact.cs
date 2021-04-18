using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillOnLaserContact : MonoBehaviour
{
    [SerializeField]
    Destructible destructible;

    [SerializeField]
    AttackType damageType;

    private void OnTriggerEnter2D(Collider2D other)
    {
        var laser = other.GetComponent<GroundAttack>();
        if (laser != null && laser.AttackType == damageType)
        {
            destructible.OnObjectDestroyed.Invoke();
        }
    }
}
