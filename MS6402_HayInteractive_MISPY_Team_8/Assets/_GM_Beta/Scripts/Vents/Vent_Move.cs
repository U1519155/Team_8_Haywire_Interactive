using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vent_Move : MonoBehaviour
{
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

    // Update is called once per frame
    void Update()
    {
        if (bl_InRangeStart == true)
        {
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
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "StartTrigger")
        {
            bl_InRangeStart = true;
        }

        if (other.tag == "EndTrigger")
        {
            bl_InRangeEnd = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        go_Press_E.SetActive(false);
        bl_InRangeStart = false;
        bl_InRangeEnd = false;
    }
}