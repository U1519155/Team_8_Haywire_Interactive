using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vent_Move : MonoBehaviour
{
    //Variables
    public GameObject go_VentSystem;
    public GameObject go_CamStartingPosition;
    public Camera Cam_VentSystem;
    public Camera Cam_OpposingCam;
    public GameObject go_Press_E;
    private bool bl_InRangeStart = false;
    private GameObject go_Player = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            bl_InRangeStart = true;
            go_Player = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        go_Press_E.SetActive(false);
        bl_InRangeStart = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (bl_InRangeStart == true)
        {
            go_Press_E.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                Cam_OpposingCam.gameObject.SetActive(false);
                go_Player.gameObject.SetActive(false);
                Cam_VentSystem.transform.position = go_CamStartingPosition.transform.position;
                go_VentSystem.SetActive(true);
                Cam_VentSystem.gameObject.SetActive(true);
                go_Press_E.SetActive(false);
                bl_InRangeStart = false;
            }
        }
    }
}