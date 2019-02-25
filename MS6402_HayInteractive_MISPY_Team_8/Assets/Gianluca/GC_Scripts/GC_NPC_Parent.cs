using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GC_NPC_Parent : MonoBehaviour
{

    public enum npc_different_states { idle, patrol, investigate, chase };      //different npc states
    public npc_different_states NPC_state = npc_different_states.idle;          //starting state
    public float fl_distance = 0.5f;     //distance agent needs to have with the target before swapping to another target
    public float fl_chase_range = 10;

    private NavMeshAgent npc_agent;
    private Transform tx_target;
    public GameObject[] GO_destinations;                                        //waypoints
    public int in_destination_index = 0;                                        //index for waypoints

    // Start is called before the first frame update
    void Start()
    {
        npc_agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (NPC_state)
        {
            case npc_different_states.patrol:
                NPC_roam();
                break;

            case npc_different_states.investigate:
                NPC_investigate();
                break;

            case npc_different_states.chase:
                NPC_chase();
                break;

        }
    }

    public void NPC_roam()
    {
        if (GM_Suspicion.bl_PCwanted == false)        //if PC is not in a restricted area
        {
            if (!npc_agent.pathPending && npc_agent.remainingDistance < fl_distance)            //if NPC is not calculating new target and he reached the actual target
            {
                Set_destination(null);              //run function for next target
            }
        }
        else
        {
            NPC_state = npc_different_states.investigate;
        }
    }

    public void NPC_investigate()
    {

    }

    public void NPC_chase()
    {
        npc_agent.SetDestination(tx_target.position);
    }

    public void Reset_target()
    {

    }

    public void Set_destination(GameObject _position)
    {
        if (_position == null)
        {
            npc_agent.destination = GO_destinations[in_destination_index].transform.position;      
                //get new destination
            in_destination_index = (in_destination_index++) % GO_destinations.Length;
                //increase index up to the maximum 
        }
        else
        {
            npc_agent.destination = _position.transform.position;
        }
    }

    public bool Find_Players ()
    {
        float _dist = Mathf.Infinity;
        GameObject _go_nearest_player = null;
        GameObject _go_Player = GameObject.FindGameObjectWithTag("Player");

        float _cur_dist = Vector3.Distance(_go_Player.transform.position, transform.position);
        if (_cur_dist < _dist)
        {
            _go_nearest_player = _go_Player;
            _dist = _cur_dist;
        }

        if (Vector3.Distance(transform.position, _go_nearest_player.transform.position) < fl_chase_range)
        {
            // Set the Target
            tx_target = _go_nearest_player.transform;
            return true;
        }

        return false;
    }
}
