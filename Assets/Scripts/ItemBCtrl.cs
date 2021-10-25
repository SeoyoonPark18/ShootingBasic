using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBCtrl : MonoBehaviour
{
    private Transform tr;
    public float rotSpeed = 1.0f;

    void Start()
    {
        tr = GetComponent<Transform>();
    }
    
    void Update()
    {
        tr.Rotate(0, 1, 0, Space.World);
    }
}
