using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy1Ctrl : MonoBehaviour
{
    public Transform playerTr;
    NavMeshAgent agent;

    Rigidbody rb;

    private float shotInterval;
    float shotTime = 0;
    public GameObject bullet;
    public GameObject enemy;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        
    }
    
    void Update()
    {
        Move(playerTr.position);

        shotInterval = Random.Range(2, 5);
        shotTime += Time.deltaTime;
        if (shotTime > shotInterval)
        {
            Attack();
            shotTime = 0;
        }
    }
  

    void Move(Vector3 pos)
    {
        if(agent.isPathStale == false)
        {
            agent.destination = pos;
            agent.isStopped = false;
        }
    }
    void Attack()
    {

        Vector3 fireDir = (new Vector3(Random.Range(-20, 20), 0, Random.Range(-20, 20)) - transform.position);
        GameObject obj = Instantiate(bullet);
        obj.transform.position = transform.position;
        obj.GetComponent<Rigidbody>().AddForce(fireDir * 50);

        Destroy(obj, 10);
    }
    private void OnDisable()
    {
        agent.enabled = false;
        GetComponent<Renderer>().material.color = Color.gray;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        Destroy(enemy, 3f);

    }
}
