using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GC_AI_Alpha : MonoBehaviour
{
    public enum npc_states { patrol, investigate, search, sleeping };
    public npc_states states = npc_states.patrol;
    public Transform[] destinations;
    private NavMeshAgent npc_agent;
    public int in_destpoint;
    public RaycastHit hit;
    public float fl_RaycastLenght = 60.0f;
    public float fl_detecttime = 2.5f;
    public float fl_detecting;
    public Transform tempdest;
    public float fl_losttime = 2.5f;
    public float fl_losing;
    public GameObject go_alert;
    public float fl_minsearchrange = 1.8f;
    public float fl_maxsearchrange = 3.8f ;
    public float fl_searchtime = 10;
    public float fl_searching;
    public float fl_sleeptime = 15;
    public float fl_sleeping;
    //public GameObject go_sleeping;

    //npc stops when looking at pc and resumes normal path if pc gets out of sight before fl_detecting > fl_detecttime
    //if npc is following pc, fl_losing only decreases when npc looks at walls


    // Start is called before the first frame update
    void Start()
    {
        npc_agent = GetComponent<NavMeshAgent>();
        Npc_patrol();

    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * fl_RaycastLenght, Color.green);
        switch (states)
        {
            case npc_states.patrol:
                Npc_patrol();
                Npc_wakeup();
                break;

            case npc_states.investigate:
                Npc_investigate();
                Npc_wakeup();
                break;

            case npc_states.search:
                Npc_search();
                Npc_wakeup();
                break;

            case npc_states.sleeping:
                Npc_Sleeping();
                break;
        }
        
        /*if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, fl_RaycastLenght))
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
        */
        //print(npc_agent.isStopped);
    }


    void Npc_patrol()
    {
        Debug.Log("patrol");
        tempdest = null;
        //go_sleeping.SetActive(false);
        fl_losing = 0;
        if (!npc_agent.pathPending && npc_agent.remainingDistance < 0.2f)       //needed for the agent to move smoothly from one point to another
        {
            npc_agent.destination = destinations[in_destpoint].position;

            in_destpoint = (in_destpoint + 1) % destinations.Length;        //restart arrays after reaching last position
        }

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, fl_RaycastLenght))
        {
            if (hit.collider.gameObject.GetComponent<CharacterController>())
            {
                fl_detecting += Time.deltaTime;     //if the PC stays in sight of the agent for long enough, he becomes the target
                npc_agent.isStopped = true;
                tempdest = hit.transform;
                npc_agent.transform.LookAt(tempdest);       //npc keeps looking at the pc
                go_alert.SetActive(true);                   //show exclamation point as visual feedback
                if (fl_detecting >= fl_detecttime)      //if the pc stayed too long in sight
                {

                    //npc_agent.destination = hit.rigidbody.position;
                    // tempdest = hit.transform;
                    states = npc_states.investigate;

                }
            }
            else
            {
                fl_detecting = 0;       //reset detecting timer
                npc_agent.isStopped = false;        //resume walking
                go_alert.SetActive(false);      //remove exclamation point
            }
        }

    }

    void Npc_investigate()
    {
        Debug.Log("investigate");
        npc_agent.isStopped = false;            //resume walking, towards PC
        npc_agent.destination = tempdest.position;
        fl_detecting = 0;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, fl_RaycastLenght))
        {       //if npc is not looking at PC - this will be changed with proper cone + raycast
            if (!hit.collider.gameObject.GetComponent<CharacterController>())
            {
                
                fl_losing += Time.deltaTime;
                if (fl_losing >= fl_losttime)
                {
                    Debug.Log("pc lost");
                    //states = npc_states.patrol;
                    states = npc_states.search;
                }
            }
            else
            {
                //fl_losing = 0;        change this later with finished AI 
            }
        }
    }

    void Npc_search ()
    {
        Debug.Log("search");
        fl_sleeping = 0;
        //go_sleeping.SetActive(false);
        if (fl_searching >= fl_searchtime)
        {
            states = npc_states.patrol;
        }
        else
        {
            fl_searching += Time.deltaTime * 2;
            if (!npc_agent.pathPending && npc_agent.remainingDistance < 0.2f)
            {
                
                npc_agent.destination = transform.position + new Vector3(Random.Range(-fl_minsearchrange, fl_maxsearchrange), 0, Random.Range(-fl_minsearchrange, fl_maxsearchrange));
            }
        }
    }

    void Npc_Sleeping()
    {
        Debug.Log("sleeping");
        //go_sleeping.SetActive(true);
        if (fl_sleeping < fl_sleeptime)
        {
            npc_agent.destination = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            fl_sleeping += Time.deltaTime;
        }
        else
        {
            states = npc_states.search;
        }
        go_alert.SetActive(false);
    }

    void Npc_wakeup()
    {
        
        GameObject go_wakeuptarget;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, fl_RaycastLenght))
        {
            if (hit.collider.gameObject.GetComponent<GC_AI_Alpha>().states == npc_states.sleeping)
            {
                Debug.Log("going to wake up");
                go_wakeuptarget = hit.collider.gameObject;
                npc_agent.destination = go_wakeuptarget.transform.position;
                if (npc_agent.remainingDistance < 1f)
                {
                    go_wakeuptarget.SendMessage("Npc_Wakeupself", SendMessageOptions.DontRequireReceiver);
                }
            }
        }

    }

    void Npc_Wakeupself ()
    {
        Debug.Log("waking up");
        states = npc_states.search;
    }
}
