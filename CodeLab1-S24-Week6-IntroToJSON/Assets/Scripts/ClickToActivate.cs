using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToActivate : MonoBehaviour
{
    void OnMouseDown()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
    }
}
