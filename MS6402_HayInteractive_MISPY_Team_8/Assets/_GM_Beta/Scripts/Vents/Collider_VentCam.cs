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

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Start_Collider")
        {
            Debug.Log("Start_Collider");
            go_Player.transform.position = go_StartTriggerGround.transform.position + new Vector3(+1, 0, 0);
            go_Player.SetActive(true);
            Cam_Parent.gameObject.SetActive(false);
        }

        if(other.name == "End_Collider")
        {
            Debug.Log("EndCollider");
            go_Player.transform.position = go_EndTriggerGround.transform.position + new Vector3(-1, 0, 0);
            go_Player.SetActive(true);
            Cam_Parent.gameObject.SetActive(false);
        }
    }
}