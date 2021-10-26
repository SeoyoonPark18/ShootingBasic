using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public int hp = 10;

    public GameObject turret;
    public float rotSpeed = 10.0f;
    public float moveSpeed = 10.0f;
    float v = 0.0f;
    Transform tr;
    Vector3 moveVer = new Vector3(0, 0, 1);

    public GameObject bullet;
    public Transform firePos;

    public float fireRate = 1.0f;
    private float nextFire = 0.0f;

    void Start()
    {
        tr = GetComponent<Transform>();
    }
    
    void Update()
    {
        v = Input.GetAxis("Vertical");
        Vector3 moveDir = (moveVer * v).normalized;
        tr.Translate(moveDir * moveSpeed * Time.deltaTime);

        
        float h = Input.GetAxis("Horizontal");
        tr.Rotate(0, h , 0, Space.World);

        float mx = Input.GetAxis("Mouse X");
        turret.transform.Rotate(Vector3.up * mx * rotSpeed);

        if (Input.GetMouseButton(0))
        {
            if (Time.time >= nextFire)
            {
                Fire();
                nextFire = Time.time + fireRate;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "ITEMY")
        {
            hp++;
            Destroy(collision.gameObject);
        }
        if (collision.collider.tag == "ITEMB")
        {
            fireRate -= 0.2f;
            Destroy(collision.gameObject);
        }
    }

    void Fire()
    {
        Instantiate(bullet, firePos.position, firePos.rotation);
    }
}
