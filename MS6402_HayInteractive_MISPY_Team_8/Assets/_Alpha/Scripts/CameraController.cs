﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    float MaxRange = 2.0f;
    public float outlineSize = 1.3f;
    public Camera cam;

    [Header("------TEXT-----")]
    public Text Txt_Interaction;

    [Header("-----ID------")]
    public int in_PCcurrentID;
    private float fl_copytime;
    public float fl_timetocopy = 5;
    

    //-------------------
    #region POC stuff
    [Header("PoC Stuff")]
    [HideInInspector]
    public GameObject screw;
    [HideInInspector]
    public GameObject glassCase;
    [HideInInspector]
    public GameObject diamond;
    [HideInInspector]
    public GameObject doorExit;
    [HideInInspector]
    public GameObject doorExitScrew;
    [HideInInspector]
    public GameObject outDoorExitScrew;
    //-------------------
    #endregion


    [Header("----- Gadget Swap -----")]
    public Transform[] weapons; // Screwdriver, watch, Cigar, normal
    public int currentWeapon;

    [Header("----- Screaming Grape -----")]
    public GameObject GO_ScreamingGrape;
    int SpawnedGrapes;

    //-----------------


    [HideInInspector]
    public RaycastHit hit;
    // public GameObject doorEnter;
    public bool bl_Diamond = false;
    // Use this for initialization

    void Start()
    {

        cam = Camera.main;
        SwapWeapon(4);
        if (Txt_Interaction != null)
        {
            Txt_Interaction.text = "";
        }

        // doorEnter.SetActive(false);
        // doorExit.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        CameraRaycast();
        InputWeapon();
        
    }

    #region Weapon Swap
    //-------
    public void SwapWeapon(int num) // weapon switcher
    {
        currentWeapon = num;
        for (int i = 0; i < weapons.Length; i++)
        {
            if (i == num)
                weapons[i].gameObject.SetActive(true);
            else
                weapons[i].gameObject.SetActive(false);
        }
    }

    
    public void InputWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))//screw driver
        {
            SwapWeapon(1);
            Player_StateManager.pc_State = Player_StateManager.PC_different_states.pc_screwDriver;
            Debug.Log(Player_StateManager.pc_State);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))//watch
        {
            SwapWeapon(2);
            Player_StateManager.pc_State = Player_StateManager.PC_different_states.pc_Watch;
            Debug.Log(Player_StateManager.pc_State);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))//cigar
        {
            SwapWeapon(3);
            Player_StateManager.pc_State = Player_StateManager.PC_different_states.pc_Cigar;
            Debug.Log(Player_StateManager.pc_State);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))//normal
        {
            SwapWeapon(4);
            Player_StateManager.pc_State = Player_StateManager.PC_different_states.pc_normal;
            Debug.Log(Player_StateManager.pc_State);
        }
    }
    #endregion

    void CameraRaycast()
    {
        int layerMask = 1 << 9;
        layerMask = ~layerMask;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, MaxRange, layerMask))
        {
            
            // Screwdriver
            if (Player_StateManager.pc_State == Player_StateManager.PC_different_states.pc_screwDriver)
            {
                
                if (hit.collider.gameObject.GetComponent<MovableScrew>())
                {
                    Txt_Interaction.text = "Press 'E' or 'mouse 1' to Unscrew";
                    if (Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.Mouse0))
                    {
                        hit.collider.gameObject.GetComponent<MovableScrew>().Rotate();
                    }
                }
                if(hit.collider == null || !hit.collider.gameObject.GetComponent<MovableScrew>())
                {
                    Txt_Interaction.text = "";
                }
                
            }
            

            // no gadgets
            if (Player_StateManager.pc_State == Player_StateManager.PC_different_states.pc_normal)
            {

                //player can flip sWITCH

                Txt_Interaction.text = "";

            }
        }
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, Mathf.Infinity, layerMask))
        {

            // Cigar
            if (Player_StateManager.pc_State == Player_StateManager.PC_different_states.pc_Cigar)
            {
                //hit marker sleep dart sound for NPC
                if (hit.collider.gameObject.GetComponent<Guard>() || hit.collider.gameObject.GetComponent<GM_ProtoAI>())
                {
                   
                    if (Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.Mouse0))
                    {
                        hit.collider.gameObject.GetComponent<GM_ProtoAI>().StartSleepTimer();
                        //CHANGE guard state to sleep for 30 seconds
                    }
                }
                else if (!hit.collider.gameObject.GetComponent<Guard>())
                {
                    if (Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.Mouse0))
                    {
                        //spawn screaming grape for a couple of seconds at endpoint of ray
                        if (SpawnedGrapes < 1)
                        {
                            Instantiate(GO_ScreamingGrape, hit.point, Quaternion.identity);
                            SpawnedGrapes++;
                            StartCoroutine(SpawntimerGrape());
                        }
                    }
                }
            }

            // EMP Watch
            if (Player_StateManager.pc_State == Player_StateManager.PC_different_states.pc_Watch)
            {
 
                if (hit.collider.gameObject.GetComponent<SecurityCamera>())
                {
                    Txt_Interaction.text = "Press 'E' or 'mouse 1' to 'disable'";
                    if (Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.Mouse0))
                    {
                        hit.collider.gameObject.GetComponent<SecurityCamera>().StartCameraCooldown(); // turns off camera for a couple of seconds
                        
                    }
                }

                if(hit.collider == null || !hit.collider.gameObject.GetComponent<SecurityCamera>())
                {
                    Txt_Interaction.text = "";
                }

                if (hit.collider.gameObject.GetComponent<GC_GuardsID>() && hit.distance <= 5 )
                {
                    Txt_Interaction.text = "Downloading ID...";
                    fl_copytime += Time.deltaTime;
                    if (fl_copytime >= fl_timetocopy)
                    {
                        in_PCcurrentID = hit.collider.GetComponent<GC_GuardsID>().in_IDcode;
                        Debug.Log("id copied");
                        Txt_Interaction.text = "ID copied";
                    }
                    //wow it actually works
                }
                else
                {
                    fl_copytime = 0;
                    
                }




                //find NPC with card, check if player is close enough to

                    // turn off tvs and other sutff just for funb

            }



            #region change shader outline POC
            //if (hit.collider.tag == "Interactable")
            //{
            //    TransformShader.changevalue = outlineSize;
            //}

            //else if (hit.collider.tag != "Interactable" || hit.collider == null)
            //{
            //    TransformShader.changevalue = 0f;
            //}
            #endregion

            #region screw case Diamond Doors POC

            //if (hit.collider.name == "Screw")
            //{
            //    if (Input.GetKey(KeyCode.F))
            //    {
            //        screw.transform.Translate(Vector3.forward * Time.deltaTime);
            //        screw.transform.Rotate(0, 0, 360 * Time.deltaTime);
            //        Destroy(screw, 0.7f);
            //    }
            //}

            //if (screw == null)
            //{
            //    if (glassCase != null)
            //    {
            //        glassCase.transform.Translate(Vector3.up * Time.deltaTime);
            //        glassCase.transform.Rotate(-65 * Time.deltaTime, 0, 0);
            //        Destroy(glassCase, 1.7f);
            //    }

            //    if (hit.collider.name == "Diamond")
            //    {
            //        if (Input.GetKey(KeyCode.F))
            //        {
            //            //Destroy(diamond, 1.2f);
            //            diamond.SetActive(false);
            //            bl_Diamond = true;
            //        }
            //    }
            //}

            ////doorExit.SetActive(true);
            ////doorEnter.SetActive(true);

            //if (hit.collider.name == "Door_Screw")
            //{
            //    if (Input.GetKey(KeyCode.F))
            //    {
            //        doorExitScrew.transform.Rotate(360 * Time.deltaTime, 0, 0);
            //        Destroy(doorExitScrew, 3f);
            //    }

            //}

            //if (doorExitScrew == null)
            //{
            //    if (doorExit != null)
            //    {
            //        doorExit.transform.Translate(Vector3.right * Time.deltaTime);
            //        doorExit.transform.Rotate(0, -100 * Time.deltaTime, 0);
            //        Destroy(doorExit, 0.8f);
            //    }
            //}

            //if (hit.collider.name == "Door_Screw_out")
            //{
            //    if (Input.GetKey(KeyCode.F))
            //    {
            //        outDoorExitScrew.transform.Rotate(360 * Time.deltaTime, 0, 0);
            //        Destroy(doorExitScrew, 3f);
            //    }
            //}

            //if (outDoorExitScrew == null)
            //{
            //    if (doorExit != null)
            //    {
            //        doorExit.transform.Translate(Vector3.right * Time.deltaTime);
            //        doorExit.transform.Rotate(0, 100 * Time.deltaTime, 0);
            //        Destroy(doorExit, 0.8f);
            //    }
            //}

            #endregion

            Debug.Log(hit.transform.name);
            Debug.DrawRay(cam.transform.position, transform.forward * MaxRange);
            //Debug.Log(fl_copytime);

            


        }
    }
    IEnumerator SpawntimerGrape()
    {
        yield return new WaitForSeconds(3);
        SpawnedGrapes--;
        ScreamingGrape.GrapeDestroy();


    }
}
