using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vent_Move : MonoBehaviour
{
    //Variables
    public GameObject go_VentSystem;
    public GameObject go_Player;
    public GameObject go_CamPosition;
    public Camera Cam_VentSystem;
    public GameObject go_Press_E;
    private bool bl_InRange = false;

    // Update is called once per frame
    void Update()
    {
        if (bl_InRange == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                go_Player.gameObject.SetActive(false);
                Cam_VentSystem.transform.position = go_CamPosition.transform.position;
                go_VentSystem.SetActive(true);
                Cam_VentSystem.gameObject.SetActive(true);
                go_Press_E.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            go_Press_E.SetActive(true);
            bl_InRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        go_Press_E.SetActive(false);
        bl_InRange = false;
    }
}