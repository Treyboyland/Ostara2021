using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldLaserFire : MonoBehaviour
{
    [SerializeField]
    GameEventVectorWorldSeed onStartLaserFire;

    [SerializeField]
    float initialY;

    [SerializeField]
    Vector2 xRange;

    [SerializeField]
    int shotsToFire;

    [SerializeField]
    float secondsBetweenShots;

    [SerializeField]
    LaserPool pool;

    public void StartFire()
    {
        StartCoroutine(FireAroundLocation(onStartLaserFire.Value1, onStartLaserFire.Value2));
    }

    void FireShot(Vector3 pos)
    {
        var shot = pool.GetObject();
        float x = Random.Range(xRange.x, xRange.y) + pos.x;
        shot.transform.position = new Vector3(x, initialY, 0);
        shot.gameObject.SetActive(true);
    }

    IEnumerator FireAroundLocation(Vector3 pos, WorldSeed seed)
    {
        int count = 0;

        while (count < shotsToFire)
        {
            FireShot(pos);
            yield return new WaitForSeconds(secondsBetweenShots);
            count++;
        }

        seed.EndSeed();
    }
}
