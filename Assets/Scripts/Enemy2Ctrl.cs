using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy2Ctrl : MonoBehaviour
{
    public Transform playerTr;
    public GameObject bullet;
    public float shotInterval = 3;
    float shotTime = 0;

    public Transform[] wayPoints;
    int nextIndex = 0;
    NavMeshAgent agent;

    Rigidbody rb;
    Renderer render;
    public GameObject enemy;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        render = GetComponent<Renderer>();
        
    }
    
    void Update()
    {



        if (agent.remainingDistance < 1.0f && agent.velocity.magnitude < 0.5f)
        {
            nextIndex = Random.Range(0, wayPoints.Length);
            Move(wayPoints[nextIndex].position);
        }

        shotTime += Time.deltaTime;
        if(shotTime > shotInterval)
        {
            Attack();
            shotTime = 0;
        }
    }
    void Move(Vector3 pos)
    {
        if (agent.isPathStale == false)
        {
            agent.destination = pos;
            agent.isStopped = false;
        }
    }

    void Attack()
    {
        Vector3 fireDir = (playerTr.position - transform.position).normalized;
        GameObject obj = Instantiate(bullet);
        obj.transform.position = transform.position;
        obj.GetComponent<Rigidbody>().AddForce(fireDir * 200);
      
        Destroy(obj, 5);
    }



    private void OnDisable()
    {
        agent.enabled = false;
        GetComponent<Renderer>().material.color = Color.gray;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        Destroy(enemy, 3f);
      
    }
}
