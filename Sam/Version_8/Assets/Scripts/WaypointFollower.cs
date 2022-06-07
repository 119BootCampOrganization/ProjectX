using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int CurrentWaypointsIndex = 0;
    [SerializeField] private float speed = 2f;

    private void Update()
    {
        if (Vector2.Distance(waypoints[CurrentWaypointsIndex].transform.position, transform.position) < .1f)
        {
            CurrentWaypointsIndex++;
            if (CurrentWaypointsIndex >= waypoints.Length)
            {
                CurrentWaypointsIndex = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[CurrentWaypointsIndex].transform.position, Time.deltaTime * speed);
    }
}
