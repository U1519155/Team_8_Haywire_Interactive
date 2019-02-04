// ---------------------- NW PC Anim Control ----------------------------
// -------------------- David Dorrington, UEL Games, 2018
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class DD_NW_PC_Anim : NetworkBehaviour
{
    private Animator pc_animator;

    // ----------------------------------------------------------------------
    // Use this for initialization
    void Start()
    {
        if (isLocalPlayer)
        {
            pc_animator = GetComponent<Animator>();
            HidePC();
        }
    }//-----     

    // ----------------------------------------------------------------------
    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer) return;

        //Local Player Functions
        AnimatePC();
    }//-----

    // ----------------------------------------------------------------------
    private void HidePC()
    {
        Renderer[] _renderers = GetComponentsInChildren<Renderer>();
        foreach (Renderer _child_renderer in _renderers)
        {
            _child_renderer.enabled = false;
        }
    }//-----

    // ----------------------------------------------------------------------
    private void AnimatePC()
    {
        //  Walking 
        if (Input.GetAxis("Vertical") > 0)
            pc_animator.SetBool("bl_walk", true);
        else
            pc_animator.SetBool("bl_walk", false);

        //  Walking Back
        if (Input.GetAxis("Vertical") < 0)
            pc_animator.SetBool("bl_walk_back", true);
        else
            pc_animator.SetBool("bl_walk_back", false);

        // Strafe
        if (Input.GetAxis("Horizontal") > 0)
            pc_animator.SetBool("bl_strafe_right", true);
        else
            pc_animator.SetBool("bl_strafe_right", false);

        if (Input.GetAxis("Horizontal") < 0)
            pc_animator.SetBool("bl_strafe_left", true);
        else
            pc_animator.SetBool("bl_strafe_left", false);

        //  Run 
        if (Input.GetKey(KeyCode.LeftShift))
            pc_animator.SetBool("bl_run", true);
        else
            pc_animator.SetBool("bl_run", false);

        //  Jump 
        if (Input.GetButtonDown("Jump"))
        {
            GetComponent<NetworkAnimator>().SetTrigger("tg_jump");
        }
    }//------
}//==========



