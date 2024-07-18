using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpinner : MonoBehaviour
{
    // Public variables to set rotation speed and direction
    public float speed = 10f;
    public bool counterclockwise = false;
    public bool spin = true;
    void Update()
    {
        if (!spin)
            return;

        // Determine the direction based on the counterclockwise toggle
        float direction = counterclockwise ? 1f : -1f;

        // Rotate the object around its up axis
        transform.Rotate(Vector3.forward, speed * direction * Time.deltaTime);
    }
}
