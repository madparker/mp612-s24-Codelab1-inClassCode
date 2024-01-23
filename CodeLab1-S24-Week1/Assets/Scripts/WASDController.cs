using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASDController : MonoBehaviour
{
    public float maxVelocity = 10;
    public float forceAmount = 100;
    Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(forceAmount * Vector3.forward);
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(forceAmount * Vector3.back);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(forceAmount * Vector3.left);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(forceAmount * Vector3.right);
        }

        if (rb.velocity.magnitude > maxVelocity)
        {
            Vector3 newVelocity = rb.velocity.normalized;
            newVelocity *= maxVelocity;
            rb.velocity = newVelocity;
        }

        Debug.Log("Current Velocity: " + rb.velocity);
    }
}
