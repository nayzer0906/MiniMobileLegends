﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class AIController : MonoBehaviour
{
    private int currentPoint = 0;
    private int currentWayPointsId;
    private Animator allyAnim;
    private NavMeshAgent currentNavMesh;
    private List<List<Transform>> wayPointsList = new List<List<Transform>>();

    public List<WayPointsController> wayPointsContList;
    void OnEnable()
    {
        allyAnim = GetComponent<Animator>();
        currentNavMesh = GetComponent<NavMeshAgent>();
        
        foreach (var wayPointsController in wayPointsContList)
        {
            wayPointsList.Add(wayPointsController.GetWayPoints());
        }
        
        if (wayPointsList == null)
            return;
        
        SelectWayPointsFromList();
        SetWayPoint();
    }

    private void SelectWayPointsFromList()
    {
        var maxWayPointsId = wayPointsList.Count - 1;
        currentWayPointsId = Random.Range(0, maxWayPointsId);
    }
    
    private void SetWayPoint()
    {
        if (wayPointsList[currentWayPointsId] == null || currentPoint >= wayPointsList[currentWayPointsId].Count)
            return;

        currentNavMesh.SetDestination(wayPointsList[currentWayPointsId][currentPoint].position);
        allyAnim.SetBool("Rival_Run", true);
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
