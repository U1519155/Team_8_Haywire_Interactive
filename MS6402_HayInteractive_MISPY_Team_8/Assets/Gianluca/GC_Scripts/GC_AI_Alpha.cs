using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GC_AI_Alpha : MonoBehaviour
{
    public enum npc_states { patrol, investigate, chase};
    public  npc_states states = npc_states.patrol;
    public Transform[] destinations;
    private NavMeshAgent npc_agent;
    public int in_destpoint;
    public RaycastHit hit;
    public float fl_RaycastLenght = 60.0f;
    public float fl_detecttime = 3.5f;
    public float fl_detecting;
    public Transform tempdest;

    //NPC STOPS WHEN PC IN RANGE AND CHASES WHEN PC IS NOT IN RAYCAST


    // Start is called before the first frame update
    void Start()
    {
        npc_agent = GetComponent<NavMeshAgent>();
        Npc_patrol();
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay (transform.position, transform.TransformDirection(Vector3.forward) * fl_RaycastLenght, Color.green);
        switch (states)
        {
            case npc_states.patrol:
                Npc_patrol();
                break;

            case npc_states.investigate:
                Npc_investigate();
                break;

            case npc_states.chase:

                break;
        }

        if (Physics.Raycast (transform.position, transform.TransformDirection(Vector3.forward), out hit, fl_RaycastLenght))
        {
            if (hit.collider.gameObject.GetComponent<CharacterController>())
            {
                fl_detecting += Time.deltaTime;
                npc_agent.isStopped = true;
                if (fl_detecting >= fl_detecttime)
                {
                    
                    //npc_agent.destination = hit.rigidbody.position;
                    tempdest = hit.transform;
                    states = npc_states.investigate;
                    
                }
            }
            else
            {
                fl_detecting = 0;
                npc_agent.isStopped = false;
            }
        }
        print(npc_agent.isStopped);
    }

    void Npc_patrol()
    {
        if (!npc_agent.pathPending && npc_agent.remainingDistance < 0.2f)
        {
            npc_agent.destination = destinations[in_destpoint].position;

            in_destpoint = (in_destpoint + 1) % destinations.Length;
        }
    }

    void Npc_investigate ()
    {
        npc_agent.isStopped = false;
        npc_agent.destination = tempdest.position; 
    }
}
