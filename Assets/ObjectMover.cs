using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    //public float timerOffset = 5f;


    public float pointA = -5f;  // Point A on the X-axis
    public float pointB = 5f;   // Point B on the X-axis
    public float duration = 15f;
    public float speed = 1f;    // Speed of movement
    public bool moveX = false;   // Toggle for X-axis movement
    public bool moveY = false;  // Toggle for Y-axis movement

    private float targetX;      // Target X position for Lerp
    private float targetY;      // Target Y position for Lerp
    private bool movingToB = true; // Direction of movement

    void Start()
    {

    }

    void Update()
    {
        if (!moveX && !moveY)
            return;

        // Determine the target position based on direction
        Vector3 targetPosition = new Vector3(0,0,0);

        if (moveX)
            targetPosition = movingToB ? new Vector3(pointB, transform.position.y, transform.position.z) : new Vector3(pointA, transform.position.y, transform.position.z);
        else if (moveY)
            targetPosition = movingToB ? new Vector3(transform.position.x, pointB, transform.position.z) : new Vector3(transform.position.x, pointA, transform.position.z);


        // Calculate the step size
        float step = speed * Time.deltaTime;

        // Move towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

        // Check if the object has reached the target position
        if (Vector3.Distance(transform.position, targetPosition) <= 0.01f)
        {
            // Toggle direction
            movingToB = !movingToB;
        }
    }

    // Method to toggle the X-axis movement
    public void ToggleMoveX()
    {
        moveX = !moveX;
    }

    // Method to toggle the Y-axis movement
    public void ToggleMoveY()
    {
        moveY = !moveY;
    }
}
