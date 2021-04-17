using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillOnLaserContact : MonoBehaviour
{
    [SerializeField]
    Destructible destructible;

    private void OnTriggerEnter2D(Collider2D other)
    {
        var laser = other.GetComponent<GroundAttack>();
        if (laser != null)
        {
            destructible.OnObjectDestroyed.Invoke();
        }
    }
}
