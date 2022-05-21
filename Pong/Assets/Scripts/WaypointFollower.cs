using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;

    [SerializeField] private float speed = 2f;

    private void Update()
    {
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
        {
            currentWaypointIndex++;
            Debug.Log("Current Waypoint : " + currentWaypointIndex);
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
                Debug.Log("Current Waypointasdadasd : " + currentWaypointIndex);
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
        Debug.Log("Current Waypoint : " + currentWaypointIndex);
    }
}
