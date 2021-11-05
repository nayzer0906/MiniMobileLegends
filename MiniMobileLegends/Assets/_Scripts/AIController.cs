using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class AIController : MonoBehaviour
{
    private int currentPoint = 0;
    private int currentWayPointsId;
    private int currentHealth;
    
    private Animator allyAnim;
    private NavMeshAgent currentNavMesh;
    private List<List<Transform>> wayPointsList = new List<List<Transform>>();
    
    [SerializeField] private int maxHealth;
    [SerializeField] private HealthBar healthBar;

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

    private void StopMoving()
    {
        currentNavMesh.Stop();
    }

    private void ResumeMoving()
    {
        currentNavMesh.Resume();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "TurretEnemy" || other.tag == "Enemy")
        {
            TakeDamage(10);
            StopMoving();
            transform.LookAt(other.transform);
            allyAnim.SetTrigger("Rival_Shoot");
        }

        if (other.tag == "WayPoint")
        {
            currentPoint++;
            SetWayPoint();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "TurretEnemy" || other.tag == "Enemy")
        {
            transform.LookAt(other.transform);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.UpdateHealth((float)currentHealth/ (float)maxHealth);
        if (currentHealth <= 0)
        {
            //Destroy(this.gameObject);
        }
    }
}
