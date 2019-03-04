using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vent_Move : MonoBehaviour
{
    //Variables
    public GameObject go_VentSystem;
    public GameObject go_CamPosition;
    public Camera Cam_VentSystem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.gameObject.SetActive(false);
            Cam_VentSystem.transform.position = go_CamPosition.transform.position;
            go_VentSystem.SetActive(true);
        }
    }
}