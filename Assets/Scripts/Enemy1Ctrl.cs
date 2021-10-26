using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy1Ctrl : MonoBehaviour
{
    public Transform playerTr;
    //public Transform[] wayPoints;
    //int nextIndex = 0;
    NavMeshAgent agent;


    public int hitCount = 3;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
    }
    
    void Update()
    {
        Move(playerTr.position);



        /*
        if (agent.remainingDistance < 1.0f && agent.velocity.magnitude < 0.5f)
        {
            nextIndex = Random.Range(0, wayPoints.Length);
            Move(wayPoints[nextIndex].position);
        } */
    }
  

    void Move(Vector3 pos)
    {
        if(agent.isPathStale == false)
        {
            agent.destination = pos;
            agent.isStopped = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("PlayerBULLET"))
        {
            if(++hitCount == 3)
            {

            }
        }
    }
}
