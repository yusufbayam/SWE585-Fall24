using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Unused right now
public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public Camera mainCamera;
    public Vector3 forcePositiveX = new Vector3(10, 0, 0);
    public Vector3 forceNegativeX = new Vector3(-10, 0, 0);
    public Vector3 forcePositiveZ = new Vector3(0, 0, 10);
    public Vector3 forceNegativeZ = new Vector3(0, 0, -10);

    void FixedUpdate()
    {
        ApplyForceInDirection();
    }

    void ApplyForceInDirection()
    {
        if (rb != null)
        {
            if (Input.GetKey(KeyCode.W))
            {
                Debug.Log("W pressed");
                rb.AddForce(forcePositiveZ);
            }
            if (Input.GetKey(KeyCode.S))
            {
                Debug.Log("S pressed");
                rb.AddForce(forceNegativeZ);
            }
            if (Input.GetKey(KeyCode.A))
            {
                Debug.Log("A pressed");
                rb.AddForce(forceNegativeX);
            }
            if (Input.GetKey(KeyCode.D))
            {
                Debug.Log("D pressed");
                rb.AddForce(forcePositiveX);
            }
        }
        else
        {
            Debug.Log("RigidBody or camera is null");
        }
    }
}