using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public Rigidbody rb;
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
        if (rb != null)
        {
            if (Input.GetKey(KeyCode.W))
            {
                Debug.Log("W pressed");
                rb.AddForce(forcePositiveZ);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                Debug.Log("S pressed");
                rb.AddForce(forceNegativeZ);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                Debug.Log("A pressed");
                rb.AddForce(forceNegativeX);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                Debug.Log("D pressed");
                rb.AddForce(forcePositiveX);
            }
        }
        else
        {
            Debug.Log("RigidBody is null");
        }
    }
}
