using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {
    public float lookDistance = 3f;
    public Transform pathWay;
    public float waitTime;
    public Light spotlight;
    public LayerMask viewMask;

    private Vector3 lastKnownLocation;
    private bool wasInSight;
    private Transform target;
    private float viewAngle;
    private Vector3[] waypoints;
    private NavMeshAgent agent;
    private Color normSpotColor;
	// Use this for initialization
	void Start () {
        wasInSight = false;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        normSpotColor = spotlight.color;
        viewAngle = spotlight.spotAngle;
        waypoints = new Vector3[pathWay.childCount];
        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = pathWay.GetChild(i).position;
        }
        agent = GetComponent<NavMeshAgent>();

        StartCoroutine(FollowPath(waypoints));
	}


    bool PlayerInView()
    {
        float dist = Vector3.Distance(target.position, transform.position);
        if (dist <= lookDistance)
        {
            Vector3 targetDirection = (target.position - transform.position).normalized;
            float angleToTarget = Vector3.Angle(transform.forward, targetDirection);
            if (angleToTarget < viewAngle / 2f)
            {
                if (!Physics.Linecast(transform.position, target.position, viewMask))
                {
                    return true;
                }
            }
        }
        return false;
    }

    IEnumerator GoToLocation(Vector3 location)
    {
        while (!((transform.position.x == location.x) && (transform.position.z == location.z)))
        {
            agent.SetDestination(location);
            yield return null;
        }
        wasInSight = false;
        yield return new WaitForSeconds(2f);
        
    }

    IEnumerator FollowPath(Vector3[] waypoints)
    {
        transform.position = waypoints[0];
        
        int waypointIndex = 1;
        Vector3 targetWaypoint = waypoints[waypointIndex];
        while (true)
        {
            if (!PlayerInView())
            {
                if (wasInSight)
                {
                    StartCoroutine(GoToLocation(lastKnownLocation));
                }
                spotlight.color = normSpotColor;
                agent.SetDestination(targetWaypoint);
                if ((transform.position.x == targetWaypoint.x) && (transform.position.z == targetWaypoint.z))
                {
                    waypointIndex = (waypointIndex + 1) % waypoints.Length;
                    targetWaypoint = waypoints[waypointIndex];
                    yield return new WaitForSeconds(waitTime);
                }
                yield return null;
            }
            else
            {
                wasInSight = true;
                spotlight.color = Color.red;
                lastKnownLocation = target.position;
                agent.SetDestination(target.position);
                yield return null;
            }
            
        }
    }

    private void OnDrawGizmos()
    {
        Vector3 previousPosition = pathWay.GetChild(0).position;
        foreach(Transform waypoint in pathWay)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(previousPosition, waypoint.position);
            previousPosition = waypoint.position;
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(waypoint.position, .3f);
        }
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lookDistance);
    }
    
}
