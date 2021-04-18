using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSeed : MonoBehaviour
{
    [SerializeField]
    GameEventVectorWorldSeed startLightRays;

    [SerializeField]
    GameEventVector startWave;

    [SerializeField]
    Vector2 yRange;

    [SerializeField]
    AnimationCurve descentCurve;

    [SerializeField]
    float secondsToDescend;

    [SerializeField]
    float secondsToWaitBeforeFiring;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnEnable()
    {
        if (gameObject.activeInHierarchy)
        {
            StartCoroutine(FireSeed());
        }
    }

    void SetPosition(Vector3 pos)
    {
        transform.position = pos;
    }

    IEnumerator AnimateY()
    {
        float elapsed = 0;
        while (elapsed < secondsToDescend)
        {
            elapsed += Time.deltaTime;
            var y = Mathf.LerpUnclamped(yRange.x, yRange.y, descentCurve.Evaluate(elapsed / secondsToDescend));
            Vector3 pos = new Vector3(transform.position.x, y, transform.position.z);
            SetPosition(pos);
            yield return null;
        }
    }

    IEnumerator FireSeed()
    {
        yield return StartCoroutine(AnimateY());
        yield return new WaitForSeconds(secondsToWaitBeforeFiring);

        startLightRays.Value1 = transform.position;
        startLightRays.Value2 = (WorldSeed)this;

        startLightRays.Invoke();
    }

    public void EndSeed()
    {
        startWave.Value = transform.position;
        startWave.Invoke();
        gameObject.SetActive(false);
    }
}
