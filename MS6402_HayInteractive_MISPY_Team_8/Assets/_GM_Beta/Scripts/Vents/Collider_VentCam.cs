using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider_VentCam : MonoBehaviour
{
    // Variables
    public GameObject go_StartTriggerGround;
    public GameObject go_EndTriggerGround;
    public GameObject go_Player;
    public Camera Cam_Parent;
    public GameObject go_Roof;

    private void Start()
    {
        //go_Roof = GameObject.Find("Main Roof");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Start_Collider")
        {
            go_Roof.SetActive(true);
            Debug.Log("Start_Collider");
            go_Player.transform.position = go_StartTriggerGround.transform.position + new Vector3(+1, 0, 0);
            go_Player.SetActive(true);
            Cam_Parent.gameObject.SetActive(false);
        }

        if(other.name == "End_Collider")
        {
            go_Roof.SetActive(true);
            Debug.Log("EndCollider");
            go_Player.transform.position = go_EndTriggerGround.transform.position + new Vector3(-1, 0, 0);
            go_Player.SetActive(true);
            Cam_Parent.gameObject.SetActive(false);
        }
    }
}