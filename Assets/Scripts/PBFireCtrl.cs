using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PBFireCtrl : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePos;

    public float fireRate = 1.0f;
    private float nextFire = 0.0f;

    void Start()
    {
        
    }
    
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if(Time.time >= nextFire)
            {
                Fire();
                nextFire = Time.time + fireRate;
            }
        }
    }
    void Fire()
    {
        Instantiate(bullet, firePos.position, firePos.rotation);
    }
}
