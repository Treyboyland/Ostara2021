using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    Vector2 xRange;

    [SerializeField]
    float speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdatePosition();
    }

    void UpdatePosition()
    {
        float x = Input.GetAxis("Horizontal") * speed * Time.deltaTime + transform.position.x;
        x = Mathf.Max(Mathf.Min(xRange.y, x), xRange.x); //Lock between range
        var pos = transform.position;
        pos.x = x;
        transform.position = pos;
    }
}
