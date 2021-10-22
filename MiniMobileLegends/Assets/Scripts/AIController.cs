using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    private int currentPoint = 0;
    private NavMeshAgent currentNavMesh;

    public List<Transform> wayPoints;
    void Start()
    {
        currentNavMesh = GetComponent<NavMeshAgent>();
        SetWayPoint();
    }

    void Update()
    {
        
    }

    private void SetWayPoint()
    {
        if (wayPoints == null || currentPoint >= wayPoints.Count)
            return;

        currentNavMesh.SetDestination(wayPoints[currentPoint].position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "WayPoint")
        {
            currentPoint++;
            SetWayPoint();
        }
    }
}
