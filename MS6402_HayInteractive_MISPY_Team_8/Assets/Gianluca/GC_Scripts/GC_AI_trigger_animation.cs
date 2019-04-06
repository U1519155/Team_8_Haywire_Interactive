using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//using UnityEngine.Animations;

public class GC_AI_trigger_animation : MonoBehaviour
{
    public enum npc_states { patrol, investigate, search, sleeping };
    public npc_states states = npc_states.patrol;
    public GameObject go_alertsign;
    public GameObject go_sleepsign;
    public GameObject go_searchsign;
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
    public float fl_searchtime = 10;
    public float fl_searching;
    public float fl_searchrange = 8;
    public float fl_sleeptime = 15;
    public float fl_sleeping;
    public GameObject go_grape;


    public Vector3 pc_position;
    public float fl_grapedistance = 10;
    public GameObject go_player;
    public GameObject go_guard;
    public GameObject go_wakeuptarget;

    public Animator anim;


    //raycast from trigger is ofset and doesn't look at player
    //also needs to add a case for npc going from search to investigate  SEE AAAAAAAAAAAAAA


    // Start is called before the first frame update
    void Start()
    {
        npc_agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
        Npc_patrol();
        go_alertsign.SetActive(false);
        go_searchsign.SetActive(false);
        go_sleepsign.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        go_grape = GameObject.Find("Screaming Ball(Clone)");
        //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * fl_RaycastLenght, Color.green);
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

    }


    void Npc_patrol()
    {
        anim.SetBool("Patrol", true);
        //Debug.Log("patrol");
        tempdest = null;
        go_sleepsign.SetActive(false);
        fl_searching = 0;
        fl_losing = 0;

        if (go_grape != null)
        {
            if (Vector3.Distance(gameObject.transform.position, go_grape.transform.position) < fl_grapedistance)
            {
                tempdest = go_grape.transform;
                anim.SetBool("Patrol", false);
                states = npc_states.investigate;
            }
        }
        if (!npc_agent.pathPending && npc_agent.remainingDistance < 0.2f)       //needed for the agent to move smoothly from one point to another
        {
            npc_agent.destination = destinations[in_destpoint].position;

            in_destpoint = (in_destpoint + 1) % destinations.Length;        //restart arrays after reaching last position
        }



        if (gameObject.GetComponentInChildren<GC_TriggerAI>().bl_pcinrange == true)       //CHANGES for trigger
        {
            //Debug.Log("jackpot");
            go_player = GetComponentInChildren<GC_TriggerAI>().go_player;
            gameObject.transform.LookAt(go_player.transform);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * fl_RaycastLenght, Color.red);
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, fl_RaycastLenght))
            {

                if (hit.collider.gameObject.GetComponent<CharacterController>())
                {
                    //Debug.Log("PC hit");
                    anim.SetBool("Still", true);
                    fl_detecting += Time.deltaTime;     //if the PC stays in sight of the agent for long enough, he becomes the target
                    npc_agent.isStopped = true;
                    tempdest = hit.transform;
                    npc_agent.transform.LookAt(tempdest);       //npc keeps looking at the pc
                    go_alertsign.SetActive(true);                   //show exclamation point as visual feedback
                    if (fl_detecting >= fl_detecttime)      //if the pc stayed too long in sight
                    {

                        //npc_agent.destination = hit.rigidbody.position;
                        // tempdest = hit.transform;
                        states = npc_states.investigate;

                    }
                }
                anim.SetBool("Still", false);
            }

        }
        else
        {
            fl_detecting = 0;       //reset detecting timer
            npc_agent.isStopped = false;        //resume walking
            go_alertsign.SetActive(false);
        }


        /*
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, fl_RaycastLenght))
        {
            if (hit.collider.gameObject.GetComponent<CharacterController>())
            {
                fl_detecting += Time.deltaTime;     //if the PC stays in sight of the agent for long enough, he becomes the target
                npc_agent.isStopped = true;
                tempdest = hit.transform;
                npc_agent.transform.LookAt(tempdest);       //npc keeps looking at the pc
                go_alertsign.SetActive(true);                   //show exclamation point as visual feedback
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
                go_alertsign.SetActive(false);      //remove exclamation point
            }
        }
        */
    }

    void Npc_investigate()
    {
        //Debug.Log("investigate");
        anim.SetBool("Investigate", true);
        npc_agent.isStopped = false;            //resume walking, towards PC
        npc_agent.destination = tempdest.position;
        go_searchsign.SetActive(false);
        go_alertsign.SetActive(true);
        fl_detecting = 0;
        /*if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, fl_RaycastLenght))
        {       //if npc is not looking at PC - this will be changed with proper cone + raycast
            if (!hit.collider.gameObject.GetComponent<CharacterController>())
            {

                fl_losing += Time.deltaTime;
                if (fl_losing >= fl_losttime)
                {
                    Debug.Log("pc lost");
                    states = npc_states.search;
                }
            }
            else
            {
                //fl_losing = 0;        change this later with finished AI 
            }
        }
        if (npc_agent.remainingDistance == 0)
        {
            states = npc_states.search;
        }*/
        if (gameObject.GetComponentInChildren<GC_TriggerAI>().bl_pcinrange == false)       //CHANGES for trigger
        {
            fl_losing += Time.deltaTime;
            if (fl_losing >= fl_losttime)
            {
                //Debug.Log("pc lost");
                anim.SetBool("Investigate", false);
                states = npc_states.search;
            }
        }
        else
        {
            go_player = GetComponentInChildren<GC_TriggerAI>().go_player;
            gameObject.transform.LookAt(go_player.transform);
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, fl_RaycastLenght))
            {
                if (hit.collider.gameObject.GetComponent<CharacterController>())
                {
                    fl_losing = 0;
                }
            }
        }
    }

    void Npc_search()
    {
        // Debug.Log("search");
        anim.SetBool("Search", true);
        fl_sleeping = 0;
        fl_losing = 0;
        go_alertsign.SetActive(false);
        if (fl_searching >= fl_searchtime)
        {
            go_searchsign.SetActive(false);
            anim.SetBool("Search", false);
            states = npc_states.patrol;
        }
        else
        {
            fl_searching += Time.deltaTime;
            go_searchsign.SetActive(true);
            if (!npc_agent.pathPending && npc_agent.remainingDistance < 0.2f)
            {
                npc_agent.destination = transform.position + new Vector3(Random.Range(-fl_searchrange, fl_searchrange), 0, Random.Range(-fl_searchrange, fl_searchrange));
            }
            /*if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, fl_RaycastLenght))
            {
                if (hit.collider.gameObject.GetComponent<CharacterController>())
                {
                    tempdest = hit.transform;
                    states = npc_states.investigate;
                }
            }*/
            if (gameObject.GetComponentInChildren<GC_TriggerAI>().bl_pcinrange == true)
            {
                go_player = GetComponentInChildren<GC_TriggerAI>().go_player;
                gameObject.transform.LookAt(go_player.transform);
                //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * fl_RaycastLenght, Color.red);
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, fl_RaycastLenght))
                {

                    if (hit.collider.gameObject.GetComponent<CharacterController>())
                    {
                        tempdest = hit.transform;
                        anim.SetBool("Search", false);
                        states = npc_states.investigate;
                    }
                }
            }
        }
    }

    void Npc_Sleeping()
    {
        //Debug.Log("sleeping");
        anim.SetBool("Sleep", true);
        if (fl_sleeping < fl_sleeptime)
        {
            npc_agent.destination = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            fl_sleeping += Time.deltaTime;
            go_sleepsign.SetActive(true);
        }
        else
        {
            go_sleepsign.SetActive(false);
            anim.SetBool("Sleep", false);
            states = npc_states.search;
        }
        go_alertsign.SetActive(false);
        go_searchsign.SetActive(false);
    }

    void Npc_wakeup()
    {

        //GameObject go_wakeuptarget;
        /*if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, fl_RaycastLenght))
        {
            if (hit.collider.gameObject.GetComponent<GC_AI_trigger>().states == npc_states.sleeping)
            {
                Debug.Log("going to wake up");
                go_wakeuptarget = hit.collider.gameObject;
                npc_agent.destination = go_wakeuptarget.transform.position;
                if (npc_agent.remainingDistance < 1f)
                {
                    go_wakeuptarget.SendMessage("Npc_Wakeupself", SendMessageOptions.DontRequireReceiver);
                }
            }
        }*/

        if (gameObject.GetComponentInChildren<GC_TriggerAI>().go_guard != null)
        {
            //Debug.Log("detected sleeping");
            go_wakeuptarget = GetComponentInChildren<GC_TriggerAI>().go_guard;
            gameObject.transform.LookAt(go_wakeuptarget.transform);
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, fl_RaycastLenght))
            {
               // Debug.Log("going to wake up");
                npc_agent.destination = go_wakeuptarget.transform.position;
                if (npc_agent.remainingDistance < 1)
                {
                    go_wakeuptarget.SendMessage("Npc_Wakeupself", SendMessageOptions.DontRequireReceiver);
                    GetComponentInChildren<GC_TriggerAI>().go_guard = null;
                    go_wakeuptarget = null;
                }
            }
        }
    }

    void Npc_Wakeupself()
    {
        //Debug.Log("waking up");
        go_sleepsign.SetActive(false);
        states = npc_states.search;
    }
}
