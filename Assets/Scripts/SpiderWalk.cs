using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderWalk : MonoBehaviour
{
     [Header("Circle Settings")]
    public Transform centerPoint;  // The center point the spider will walk around
    public float radius = 5f;      // Circle radius
    public float speed = 2f;       // Movement speed (degrees per second)

    [Header("Animation Settings")]
    public Animator spiderAnimator; // Optional: walking animation

    private float angle = 0f;

    void Update()
    {
        if (centerPoint == null)
            return;

        // Increase angle over time
        angle += speed * Time.deltaTime;

        // Convert to radians
        float rad = angle * Mathf.Deg2Rad;

        // Compute new position on the circle
        float x = centerPoint.position.x + Mathf.Cos(rad) * radius;
        float z = centerPoint.position.z + Mathf.Sin(rad) * radius;
        float y = transform.position.y; // Keep same height

        transform.position = new Vector3(x, y, z);

        // Make the spider face the direction it's moving
        Vector3 direction = (centerPoint.position - transform.position).normalized;
        Vector3 tangent = Vector3.Cross(Vector3.up, direction);
        transform.rotation = Quaternion.LookRotation(tangent, Vector3.up);

        // Play walking animation if available
        if (spiderAnimator != null)
        {
            spiderAnimator.SetBool("isWalking", true);
        }
    }
}
