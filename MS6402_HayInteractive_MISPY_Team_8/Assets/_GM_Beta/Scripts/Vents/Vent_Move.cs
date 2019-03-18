using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vent_Move : MonoBehaviour
{
    [Header("First Vent = Normal Tag")]
    //Variables
    public GameObject go_VentSystem;
    public GameObject go_Player;
    public GameObject go_StartCamPosition;
    public GameObject go_EndCamPosition;
    public Camera Cam_StartVentSystem;
    public Camera Cam_EndVentSystem;
    public GameObject go_Press_E;
    private bool bl_InRangeStart = false;
    private bool bl_InRangeEnd = false;

    [Header("Second Vent = Tag Normal1")]
    public GameObject go_VentSystem1;
    public GameObject go_Player1;
    public GameObject go_StartCamPosition1;
    public GameObject go_EndCamPosition1;
    public Camera Cam_StartVentSystem1;
    public Camera Cam_EndVentSystem1;
    public GameObject go_Press_E1;
    private bool bl_InRangeStart1 = false;
    private bool bl_InRangeEnd1 = false;

    [Header("Second Vent = Tag Normal2")]
    public GameObject go_VentSystem2;
    public GameObject go_Player2;
    public GameObject go_StartCamPosition2;
    public GameObject go_EndCamPosition2;
    public Camera Cam_StartVentSystem2;
    public Camera Cam_EndVentSystem2;
    public GameObject go_Press_E2;
    private bool bl_InRangeStart2 = false;
    private bool bl_InRangeEnd2 = false;

    // Update is called once per frame
    void Update()
    {
        if (bl_InRangeStart == true)
        {
            bl_InRangeEnd = false;
            go_Press_E.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                go_Player.gameObject.SetActive(false);
                Cam_StartVentSystem.transform.position = go_StartCamPosition.transform.position;
                go_VentSystem.SetActive(true);
                Cam_StartVentSystem.gameObject.SetActive(true);
                go_Press_E.SetActive(false);
            }
        }

        if (bl_InRangeEnd == true)
        {

            go_Press_E.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                go_Player.gameObject.SetActive(false);
                Cam_EndVentSystem.transform.position = go_EndCamPosition.transform.position;
                go_VentSystem.SetActive(true);
                Cam_EndVentSystem.gameObject.SetActive(true);
                go_Press_E.SetActive(false);
            }
        }

        if (bl_InRangeStart1 == true)
        {
            bl_InRangeEnd1 = false;
            go_Press_E1.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                go_Player1.gameObject.SetActive(false);
                Cam_StartVentSystem1.transform.position = go_StartCamPosition1.transform.position;
                go_VentSystem1.SetActive(true);
                Cam_StartVentSystem1.gameObject.SetActive(true);
                go_Press_E1.SetActive(false);
            }
        }

        if (bl_InRangeEnd1 == true)
        {

            go_Press_E1.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                go_Player1.gameObject.SetActive(false);
                Cam_EndVentSystem1.transform.position = go_EndCamPosition1.transform.position;
                go_VentSystem1.SetActive(true);
                Cam_EndVentSystem1.gameObject.SetActive(true);
                go_Press_E1.SetActive(false);
            }
        }

        if (bl_InRangeStart1 == true)
        {
            bl_InRangeEnd1 = false;
            go_Press_E1.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                go_Player1.gameObject.SetActive(false);
                Cam_StartVentSystem1.transform.position = go_StartCamPosition1.transform.position;
                go_VentSystem1.SetActive(true);
                Cam_StartVentSystem1.gameObject.SetActive(true);
                go_Press_E1.SetActive(false);
            }
        }

        if (bl_InRangeEnd2 == true)
        {

            go_Press_E2.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                go_Player2.gameObject.SetActive(false);
                Cam_EndVentSystem2.transform.position = go_EndCamPosition2.transform.position;
                go_VentSystem2.SetActive(true);
                Cam_EndVentSystem2.gameObject.SetActive(true);
                go_Press_E2.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "StartTrigger")
        {
            bl_InRangeStart = true;
            bl_InRangeEnd = false;
        }

        if (other.tag == "EndTrigger")
        {
            bl_InRangeEnd = true;
            bl_InRangeStart = false;
        }

        if (other.tag == "EndTrigger1")
        {
            bl_InRangeEnd1 = true;
            bl_InRangeStart1 = true;
        }

        if (other.tag == "StartTrigger1")
        {
            bl_InRangeStart1 = true;
            bl_InRangeEnd1 = false;
        }

        if (other.tag == "EndTrigger2")
        {
            bl_InRangeEnd2 = true;
            bl_InRangeStart2 = true;
        }

        if (other.tag == "StartTrigger2")
        {
            bl_InRangeStart2 = true;
            bl_InRangeEnd2 = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        go_Press_E.SetActive(false);
        bl_InRangeStart = false;
        bl_InRangeEnd = false;
        bl_InRangeStart1 = false;
        bl_InRangeEnd1 = false;
        bl_InRangeStart2 = false;
        bl_InRangeEnd2 = false;
    }
}