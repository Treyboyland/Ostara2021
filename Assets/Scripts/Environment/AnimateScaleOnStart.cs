using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateScaleOnStart : MonoBehaviour
{
    [SerializeField]
    ScaleStats stats;

    void SetScale(float value)
    {
        Vector3 newScale = new Vector3(value, value, value);
        transform.localScale = newScale;
    }

    private void OnEnable()
    {
        if (gameObject.activeInHierarchy)
        {
            StartCoroutine(AnimateScale());
        }
    }


    IEnumerator AnimateScale()
    {
        SetScale(0);
        float elapsed = 0;
        float maxScale = stats.GetMaxScale();
        float secondsToAnimate = stats.GetAnimationTime() / 2;

        while (elapsed < secondsToAnimate)
        {
            elapsed += Time.deltaTime;
            SetScale(Mathf.Lerp(0, maxScale, elapsed / secondsToAnimate));
            yield return null;
        }

        SetScale(maxScale);
        elapsed = 0;

        while (elapsed < secondsToAnimate)
        {
            elapsed += Time.deltaTime;
            SetScale(Mathf.Lerp(maxScale, 1, elapsed / secondsToAnimate));
            yield return null;
        }
    }


}
