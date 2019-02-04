using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DD_NW_RayGun : NetworkBehaviour
{

    // ----------------------------------------------------------------------
    // Range Weapon Variables
    public int in_damage = 10;
    public float fl_cooldown = 0.1F;
    public float fl_accuracy = 100;
    private float fl_range = 50;
    public float fl_hit_force = 100;
    private float fl_next_attack_time;
    public Transform tx_weapon;
    private LineRenderer line_laser;
    private Camera go_PC_camera;

    // ----------------------------------------------------------------------
    // Use this for initialization
    void Start()
    {
        if (!isLocalPlayer) return;

        // Local Player 
        line_laser = GetComponent<LineRenderer>();
        tx_weapon = transform.Find("Gun").transform;
        go_PC_camera = GetComponentInChildren<Camera>();
    }//----

    // ----------------------------------------------
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("o")) Cursor.lockState = CursorLockMode.Locked;
        if (Input.GetKeyDown("i")) Cursor.lockState = CursorLockMode.None;

        // These functions are only called on the local player
        if (isLocalPlayer)
        {
            RayAttack();
        }
    } //-----

    // ----------------------------------------------------------------------
    void RayAttack()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > fl_next_attack_time)
        {
            fl_next_attack_time = Time.time + fl_cooldown;
            StartCoroutine(ShotEffect());

            Vector3 _v3_ray_origin = go_PC_camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));
            RaycastHit _hit;

            // set the line renderer start to the weapon
            line_laser.SetPosition(0, tx_weapon.position);

            // cast a ray and has it hit something
            if (Physics.Raycast(_v3_ray_origin, go_PC_camera.transform.forward, out _hit, fl_range))
            {
                if (_hit.rigidbody) // push the rigidbody
                {
                    rb_target = _hit.rigidbody;
                    v3_hit_normal = _hit.normal;
                }

                line_laser.SetPosition(1, _hit.point); // set the line end pos

                // Assign the target
                if (_hit.collider.GetComponent<NetworkIdentity>())
                {
                    go_target = _hit.collider.gameObject; // set target 

                    if (isServer)
                        RpcOnHitGOChanged();
                    else
                        CmdOnHitGOChanged();
                }
            }
            else
            {   // set the end of the line renderer and the range
                line_laser.SetPosition(1, _v3_ray_origin + (go_PC_camera.transform.forward) * fl_range);
            }
        }
    }//-----


    // ----------------------------------------------
    private GameObject go_target;
    private Rigidbody rb_target;
    private Vector3 v3_hit_normal;


    [Command] // sent from local player to server
    void CmdOnHitGOChanged()
    {
        RpcOnHitGOChanged();

        //  if (isServer)  ApplyDamage();

    }//-----


    [ClientRpc] // sent from objects on the server to objects on clients
    void RpcOnHitGOChanged()
    {
        //if (isClient)
        ApplyDamage();
    }//------


    void ApplyDamage()
    {
        if (go_target)
        {
            print(go_target);

            if (go_target.GetComponent<DD_NW_Health>())
                go_target.GetComponent<DD_NW_Health>().Damage(in_damage);

            if (go_target.GetComponent<DD_NW_NPC_Health>())
                go_target.GetComponent<DD_NW_NPC_Health>().Damage(in_damage);
        }

        if (rb_target) rb_target.AddForce(-v3_hit_normal * fl_hit_force);

    }//-----



    // ----------------------------------------------
    // Coroutine for displaying for laser line
    private IEnumerator ShotEffect()
    {   //add sound fx here 

        line_laser.enabled = true;
        yield return new WaitForSeconds(0.07F);
        line_laser.enabled = false;
    }//----
}//==========
