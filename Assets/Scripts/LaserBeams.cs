using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeams : MonoBehaviour
{
    [SerializeField]
    Camera mainCamera;

    [Range(1, 2)]
    [SerializeField]
    float rangeMultiplier;

    [SerializeField]
    GameEvent laserFired;

    [SerializeField]
    GameEvent laserStopped;

    public bool CanLaser { get; set; } = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (CanLaser && Input.GetButton("Fire"))
        {
            laserFired.Invoke();
            SetCorrectAngle();
            SetCorrectLength();
        }
        else
        {
            laserStopped.Invoke();
            var gone = transform.localScale;
            gone.y = 0;
            transform.localScale = gone;
        }
    }

    void SetCorrectAngle()
    {
        var mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = transform.position.z;
        //Debug.LogWarning("Mouse World: " + mousePos);
        float angle = Vector3.Angle(mousePos - transform.position, Vector3.down);
        if (transform.position.x > mousePos.x)
        {
            //For some reason, we need to flip this if we are ahead of the coin
            angle *= -1;
        }
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void SetCorrectLength()
    {
        var mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = transform.position.z;
        var scale = transform.localScale;
        scale.y = Mathf.Abs(Vector3.Distance(mousePos, transform.position)) * rangeMultiplier;
        transform.localScale = scale;
    }
}
