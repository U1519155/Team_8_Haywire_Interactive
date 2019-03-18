using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeAndStore : MonoBehaviour
{
    //Attach this script to the trigger childed to the key.
    //Variables
    public GameObject go_Key;
    public GameObject go_PressE;
    private bool bl_InRange = false;
    public static bool bl_HasKey = false;

    // Update is called once per frame
    void Update()
    {
        if (bl_InRange == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                go_PressE.SetActive(false);
                go_Key.SetActive(false);
                bl_HasKey = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            go_PressE.SetActive(true);
            bl_InRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        bl_InRange = false;
    }
}