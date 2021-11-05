using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointsController : MonoBehaviour
{
    private List<Transform> wayPoints = new List<Transform>();
    
    public List<Transform> GetWayPoints()
    {
        var wayPointsArray = transform.GetComponentsInChildren<CheckPointController>();
        foreach (var point in wayPointsArray)
        {
            var pointTransform = point.GetTransform();
            wayPoints.Add(pointTransform);
        }

        return wayPoints;
    }
}
