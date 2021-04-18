using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnBaseAnimationState : MonoBehaviour
{
    [SerializeField]
    Animator animator;

    [SerializeField]
    string animationName;

    private void OnEnable()
    {
        if (gameObject.activeInHierarchy)
        {
            StartCoroutine(WaitThenDisable());
        }
    }


    IEnumerator WaitThenDisable()
    {
        while (!animator.GetCurrentAnimatorStateInfo(0).IsName(animationName))
        {
            yield return null;
        }

        gameObject.SetActive(false);
    }
}
