using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PBFireCtrl : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePos;

    void Start()
    {
        
    }
    
    void Update()
    {
        //InvokeRepeating("Invoketimer", 1f, 1f);
        if (Input.GetMouseButton(0))
        {
            GameObject obj = Instantiate(bullet, firePos.position, firePos.rotation);
        }
    }

    void Invoketimer()
    {
        if (Input.GetMouseButton(0))
        {
            GameObject obj = Instantiate(bullet, firePos.position, firePos.rotation);
        }
        
    }
}
