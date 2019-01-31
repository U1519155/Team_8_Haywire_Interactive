using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DD_NPC_NM : MonoBehaviour
{

    // ----------------------------------------------------------------------
    public enum en_states { Idle, Attack, Roam, Flee, Recharge };
    public en_states NPC_state = en_states.Idle;
       
    private Transform tx_target;
    private NavMeshAgent nm_agent;
    public int in_roam_range = 40;

    public float fl_HP = 100;
    public float fl_HP_Max = 100;
    public float fl_chase_range = 10;
    public float fl_attack_range = 5;
    // Combat
    public float fl_cool_down = 1;
    private float fl_next_shot_time;
    public GameObject go_projectile;


    // ----------------------------------------------------------------------
    void Start()
    {
        nm_agent = GetComponent<NavMeshAgent>();
    }//-----


    // ----------------------------------------------------------------------
    // Update is called once per frame
    void Update()
    {
        SwitchStates();
        UpdateHP();

    }//-----

    // ----------------------------------------------------------------------
    private void SwitchStates()
    {
        if (fl_HP < 30) NPC_state = en_states.Recharge;
        //if (float_HP > 50) NPC_state = en_states.Roam;

        switch (NPC_state)
        {
            case en_states.Idle:
                if (fl_HP > 40) NPC_state = en_states.Roam;
                break;

            case en_states.Roam:
                RoamWorld();
                break;

            case en_states.Recharge:
                RechargeHP();
                break;

            case en_states.Attack:
                AttackEnemy();
                break;

            case en_states.Flee:
                break;
        }
    }//-----

   


    
    // ----------------------------------------------------------------------
    private void AttackEnemy()
    {
        // Set Target
        nm_agent.SetDestination(tx_target.position);

        // Fire at target

        if (Vector3.Distance(transform.position, nm_agent.destination) < fl_attack_range)
        {
            //transform.LookAt(tx_target.position);

            if (fl_next_shot_time < Time.time)
            {
                FireBullet();
                fl_next_shot_time = Time.time + fl_cool_down;
            }
        }

    }//-----

    // ----------------------------------------------------------------------
  //  [Command]
    void FireBullet()
    {
        // Create a bullet and reset the shot timer

        var _bullet = (GameObject)Instantiate(go_projectile, transform.position + transform.TransformDirection(new Vector3(0, 1, 1.5F)), transform.rotation);
        fl_next_shot_time = Time.time + fl_cool_down;

       // NetworkServer.Spawn(_bullet);

    }//-----


    // ----------------------------------------------------------------------
    private void RechargeHP()
    {
        nm_agent.SetDestination(GameObject.Find("Home").transform.position);
        if (fl_HP > 60) NPC_state = en_states.Roam;
    }//-----



    // ----------------------------------------------------------------------
    private void RoamWorld()
    {
        if (!FindPlayers())
        {
            if (Vector3.Distance(transform.position, nm_agent.destination) < 4)
            {
                nm_agent.SetDestination(new Vector3(Random.Range(-in_roam_range, in_roam_range), 0, Random.Range(-in_roam_range, in_roam_range)));
            }
        }
        else
        {
            NPC_state = en_states.Attack;
        }
    }//-----

    // ----------------------------------------------------------------------
    bool FindPlayers()
    {
        // temp variables
        float _dist = Mathf.Infinity;
        GameObject _go_nearest_player = null;
        GameObject[] _go_Players = GameObject.FindGameObjectsWithTag("Player");

        // Are there any tagged targets in the scene?
        if (_go_Players.Length > 0)
        {
            // Loop through the list of targets
            foreach (GameObject _go in _go_Players)
            {
                float _cur_dist = Vector3.Distance(_go.transform.position, transform.position);
                if (_cur_dist < _dist)
                {
                    _go_nearest_player = _go;
                    _dist = _cur_dist;
                }
            }

            if (Vector3.Distance(transform.position, _go_nearest_player.transform.position) < fl_chase_range)
            {
                // Set the Target
                tx_target = _go_nearest_player.transform;
                return true;
            }
        }

        return false;
    }//----- 



    // ----------------------------------------------------------------------
    private void UpdateHP()
    {
        GetComponentInChildren<TextMesh>().text = Mathf.Round(fl_HP).ToString();

        if (fl_HP > fl_HP_Max) fl_HP = fl_HP_Max;

    }//-----

    // ----------------------------------------------------------------------
    public void Damage(float fl_damage)
    {
        fl_HP -= fl_damage;

    }//----

    

}//========
