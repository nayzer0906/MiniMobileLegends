using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemyAIController : MonoBehaviour
{
    private int currentPoint = 0;
    private int currentWayPointsId;
    private int currentHealth;
    
    private Animator enemyAnim;
    private NavMeshAgent currentNavMesh;
    private List<List<Transform>> wayPointsList = new List<List<Transform>>();
    
    [SerializeField] private int maxHealth;
    [SerializeField] private HealthBar healthBar;

    public List<WayPointsController> wayPointsContList;
    private EnemyChoosesColor _enemyChoosesColor;
    private bool isCooldown = false;
    void OnEnable()
    {
        currentHealth = maxHealth;
        enemyAnim = GetComponent<Animator>();
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
        enemyAnim.SetBool("Rival_Run", true);
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
        if(other.tag == "TurretAlly")
        {
            //StopMoving();
            transform.LookAt(other.transform);
        }
        
        if (other.tag == "EnemyWayPoint")
        {
            currentPoint++;
            SetWayPoint();
        }
    }
    
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "TurretAlly")
        {
            if (!isCooldown)
                StartCoroutine(TakeDamage(10));
        }
    }
    
    public IEnumerator TakeDamage(int damage)
    {
        isCooldown = true;
        currentHealth -= damage;
        healthBar.UpdateHealth((float)currentHealth/ (float)maxHealth);

        yield return new WaitForSeconds(0.5f);
        isCooldown = false;
        
        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
