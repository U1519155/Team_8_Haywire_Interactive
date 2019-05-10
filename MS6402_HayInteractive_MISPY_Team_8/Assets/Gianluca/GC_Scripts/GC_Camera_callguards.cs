﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GC_Camera_callguards : MonoBehaviour
{
    public static event System.Action OnGuardHasSpottedPlayer;

    public float speed = 5;
    public float waitTime = .3f;
    public float turnSpeed = 90;
    public float timeToSpotPlayer = .5f;
    public bool stopAtPlayer = false;

    public Light spotlight;
    public float viewDistance;
    public LayerMask viewMask;

    float viewAngle;
    float playerVisibleTimer;

    public Transform pathHolder;
    Transform player;
    Color originalSpotlightColour;

    public GameObject[] go_guardlist;
    [HideInInspector]    public int index = 1;
    [HideInInspector]    public GameObject go_tempguard;
    [HideInInspector]    public GameObject go_nearestguard;
    [HideInInspector]    public Vector3 v3_pclocation;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        viewAngle = spotlight.spotAngle;
        originalSpotlightColour = spotlight.color;
        if (pathHolder != null)
        {
            Vector3[] waypoints = new Vector3[pathHolder.childCount];
            for (int i = 0; i < waypoints.Length; i++)
            {
                waypoints[i] = pathHolder.GetChild(i).position;
                waypoints[i] = new Vector3(waypoints[i].x, transform.position.y, waypoints[i].z);
            }

            StartCoroutine(FollowPath(waypoints));
        }

    }

    public void Update()
    {

        //Debug.Log(GM_Teleport.bl_Teleport);

        if (CanSeePlayer())
        {
            playerVisibleTimer += Time.deltaTime;
            stopAtPlayer = true;
        }
        else
        {
            playerVisibleTimer -= Time.deltaTime;
            stopAtPlayer = false;
        }


        playerVisibleTimer = Mathf.Clamp(playerVisibleTimer, 0, timeToSpotPlayer);
        spotlight.color = Color.Lerp(originalSpotlightColour, Color.red, playerVisibleTimer / timeToSpotPlayer);

        if (spotlight.color == Color.red)
        {
            GM_Teleport.bl_Teleport = true;
        }

        if (playerVisibleTimer >= timeToSpotPlayer)
        {
            if (OnGuardHasSpottedPlayer != null)
            {
                OnGuardHasSpottedPlayer();
            }
            v3_pclocation = player.transform.position;
            CheckGuardsDistance();
            Callguard();
        }
    }
    void CheckedPlayer()
    {

    }
    bool CanSeePlayer()
    {
        if (Vector3.Distance(transform.position, player.position) < viewDistance)
        {


            Vector3 dirToPlayer = (player.position - transform.position).normalized;
            float angleBetweenGuardAndPlayer = Vector3.Angle(transform.forward, dirToPlayer);
            if (angleBetweenGuardAndPlayer < viewAngle / 2f)
            {
                if (!Physics.Linecast(transform.position, player.position, viewMask))
                {
                    return true;
                }
            }

        }
        return false;
    }

    IEnumerator FollowPath(Vector3[] waypoints)
    {

        transform.position = waypoints[0];
        int targetWaypointIndex = 1;
        Vector3 targetWaypoint = waypoints[targetWaypointIndex];
        if (stopAtPlayer == false)
        {
            transform.LookAt(targetWaypoint);

            while (true)
            {
                if (stopAtPlayer == false)
                {
                    transform.position = Vector3.MoveTowards(transform.position, targetWaypoint, speed * Time.deltaTime);
                    if (transform.position == targetWaypoint)
                    {
                        targetWaypointIndex = (targetWaypointIndex + 1) % waypoints.Length;
                        targetWaypoint = waypoints[targetWaypointIndex];
                        yield return new WaitForSeconds(waitTime);
                        yield return StartCoroutine(TurnToFace(targetWaypoint));
                    }
                }
                else
                {
                    transform.LookAt(player);
                }
                yield return null;

            }
        }


    }

    IEnumerator TurnToFace(Vector3 lookTarget)
    {
        Vector3 dirToLookTarget = (lookTarget - transform.position).normalized;
        float targetAngle = 90 - Mathf.Atan2(dirToLookTarget.z, dirToLookTarget.x) * Mathf.Rad2Deg;

        while (Mathf.Abs(Mathf.DeltaAngle(transform.eulerAngles.y, targetAngle)) > 0.05f)
        {
            float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetAngle, turnSpeed * Time.deltaTime);
            transform.eulerAngles = Vector3.up * angle;
            yield return null;
        }
    }

    /*void OnDrawGizmos() {
		Vector3 startPosition = pathHolder.GetChild (0).position;
		Vector3 previousPosition = startPosition;

		foreach (Transform waypoint in pathHolder) {
			Gizmos.DrawSphere (waypoint.position, .3f);
			Gizmos.DrawLine (previousPosition, waypoint.position);
			previousPosition = waypoint.position;
		}
		Gizmos.DrawLine (previousPosition, startPosition);

		Gizmos.color = Color.red;
		Gizmos.DrawRay (transform.position, transform.forward * viewDistance);
	}
*/
    public void CheckGuardsDistance()
    {
        go_nearestguard = go_guardlist[0];
        foreach (GameObject guard in go_guardlist)
        {
            
            go_tempguard = go_guardlist[index];
            
            if (Vector3.Distance(gameObject.transform.position, go_nearestguard.transform.position) > (Vector3.Distance(gameObject.transform.position, go_tempguard.transform.position)))
            {
                go_nearestguard = go_tempguard;
            }
            else
            {
                index = (index +1) % go_guardlist.Length;
            }
        }
    }

    public void Callguard()
    {
        if (go_nearestguard.GetComponent<GC_AI_trigger>().states != GC_AI_trigger.npc_states.sleeping)
        {
            go_nearestguard.GetComponent<GC_AI_trigger>().npc_agent.destination = v3_pclocation;
        }
    }

}