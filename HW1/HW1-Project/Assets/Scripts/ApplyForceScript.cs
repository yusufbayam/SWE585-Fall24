using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyForceScript : MonoBehaviour
{
    public Rigidbody rb;
    public Vector3 force = new Vector3(0, 0.3f, 0);
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start called!");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update called!");
        if (rb != null) {
            rb.AddForce(force);
        }
    }
}
