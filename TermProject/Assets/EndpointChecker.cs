using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndpointChecker : MonoBehaviour
{
    public Transform endpoint;
    private float threshold = 0.5f; // Distance threshold to consider as "reached"

    // Setter to configure the endpoint
    public void SetEndpoint(Transform targetEndpoint)
    {
        endpoint = targetEndpoint;
    }

    void Update()
    {
        // Check if the object has reached the endpoint
        float distance = Vector3.Distance(transform.position, endpoint.position);
        Debug.Log($"Transform pos: {transform.position}");
        Debug.Log(endpoint.position);
        Debug.Log(distance);
        if (distance <= threshold)
        {
            Debug.Log($"Object {name} reached the endpoint ({endpoint}) and will be destroyed.");
            Destroy(gameObject); // Remove the object
        }
    }
}
