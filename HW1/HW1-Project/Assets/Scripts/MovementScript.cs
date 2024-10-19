using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public Rigidbody rb;
    public Camera mainCamera;
    public Vector3 forcePositiveX = new Vector3(10, 0, 0);
    public Vector3 forceNegativeX = new Vector3(-10, 0, 0);
    public Vector3 forcePositiveZ = new Vector3(0, 0, 10);
    public Vector3 forceNegativeZ = new Vector3(0, 0, -10);
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        ApplyForceInDirection();
    }

    void ApplyForceInDirection()
    {
            Vector3 forward = mainCamera.transform.forward;
            forward.y = 0; // Keep only horizontal direction
            forward.Normalize();

            Vector3 right = mainCamera.transform.right;
            right.y = 0; // Keep only horizontal direction
            right.Normalize();
        if (rb != null)
        {
            if (Input.GetKey(KeyCode.W))
            {
                Debug.Log("W pressed");
                rb.AddForce(forward * forcePositiveZ.z);
            }
            if (Input.GetKey(KeyCode.S))
            {
                Debug.Log("S pressed");
                rb.AddForce(forward * forceNegativeZ.z);
            }
            if (Input.GetKey(KeyCode.A))
            {
                Debug.Log("A pressed");
                rb.AddForce(right * forceNegativeX.x);
            }
            if (Input.GetKey(KeyCode.D))
            {
                Debug.Log("D pressed");
                rb.AddForce(right * forcePositiveX.x);
            }
        }
        else
        {
            Debug.Log("RigidBody or camera is null");
        }
    }
}
