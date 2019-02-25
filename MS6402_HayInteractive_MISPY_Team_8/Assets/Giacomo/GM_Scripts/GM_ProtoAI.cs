﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

public class GM_ProtoAI : MonoBehaviour
{
    //Variables - AI and Pathfinding.
    public Transform[] Goals;
    private NavMeshAgent Agent_Self;
    private int in_Number;
    private bool bl_Time = false;
    public float fl_WaitTime = 7f;
    private float fl_Overtime;
    public int LengthRaycast = 10;
    private bool bl_IsStopped = false;
    private bool bl_Stop = false;
    private float fl_Stop;
    public float fl_WaitStopped = 10f;

    // Use this for initialization
    void Start()
    {
        //Makes sure the NPC has a NavMeshAgent component and if it doesn't it adds one.
        Agent_Self = GetComponent<NavMeshAgent>();
        if (Agent_Self != GetComponent<NavMeshAgent>())
        {
            Agent_Self.gameObject.AddComponent<NavMeshAgent>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Sets a goal for the NPC.
        if (bl_Time == false)
        {
            in_Number = Random.Range(0, Goals.Length);
            bl_Time = true;
            fl_Overtime = 0;
        }

        //Waits a set amount of seconds (fl_WaitTime) before setting the next destination.
        if (bl_Time == true)
        {
            fl_Overtime += Time.deltaTime;

<<<<<<< HEAD
<<<<<<< HEAD
            if (fl_Overtime >= fl_WaitTime)
=======
            if (bl_Stop == true)
            {
                fl_Stop += Time.deltaTime;

                if (fl_Stop >= fl_WaitStopped)
                {
                    bl_IsStopped = true;
                    bl_Stop = false;
                    Unstop();
                }
            }
            //Tells the NPC to go to the set destination.            
            if (Agent_Self.destination != null)
>>>>>>> parent of ea29469... Merge branch 'master' of https://github.com/U1519155/Team_8_Haywire_Interactive
=======
            if (fl_Overtime >= fl_WaitTime)
>>>>>>> parent of b05a167... Commit
            {
                bl_Time = false;
            }
        }

        if (bl_Stop == true)
        {
            fl_Stop += Time.deltaTime;

            if (fl_Stop >= fl_WaitStopped)
            {
                bl_IsStopped = true;
                bl_Stop = false;
                Unstop();
            }
        }

        //Tells the NPC to go to the set destination.
        Agent_Self.destination = Goals[in_Number].position;

        //Declaring a variable to make sure the Raycast turns red once Layer 9 is hit --> Set the Player (Capsule) as Layer 9.
        int layermask = 1 << 9;
        RaycastHit hit;

        //Draws a raycast with length LengthRaycast that turns red once it hits the player (The player needs to be set to layer 9 for
        //this to work. Stops the NPC for fl_WaitStopped seconds (check the Update function to find this variable).
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, LengthRaycast, layermask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);

            bl_IsStopped = false;

            if (bl_IsStopped == false)
            {
                Agent_Self.isStopped = true;
                fl_Stop = 0;
                bl_Stop = true;
            }

        }

        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * LengthRaycast, Color.yellow);
        }
    }

    public void StartSleepTimer()
    {
        StartCoroutine(SleepAI());
    }
    IEnumerator SleepAI ()
    {
       // Agent_Self.speed = 0;
        Agent_Self.enabled = false;
        print(Agent_Self.enabled);
        //Agent_Self.destination = Agent_Self.transform.position;
        yield return new WaitForSeconds(20);
       // Agent_Self.speed = 5;
        Agent_Self.enabled = true;
        print(Agent_Self.enabled);
        
    }


    private void Unstop()
    {
        Agent_Self.isStopped = false;
    }
}