using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemYCtrl : MonoBehaviour
{
    private Transform tr;

    void Start()
    {
        tr = GetComponent<Transform>();
    }

    void Update()
    {
        tr.Rotate(0, 1, 0, Space.World);
    }

    
}
