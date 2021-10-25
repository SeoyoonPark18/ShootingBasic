using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PBCtrl : MonoBehaviour
{
    public float speed = 500.0f;

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * speed);
    }
    
    void Update()
    {
        
    }
}
