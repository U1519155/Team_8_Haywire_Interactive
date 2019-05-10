using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_NewTeleport : MonoBehaviour
{
    //Variables
    private GameObject go_Player;
    private bool bl_InDistance = false;
    public float fl_Distance = 8f;
    public GameObject go_PressE;
    public GameObject go_WhereTo;

    // Use this for initialization
    void Start()
    {
        go_Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (bl_InDistance == true)
        {
            go_PressE.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                go_Player.transform.position = go_WhereTo.transform.position;
                go_PressE.SetActive(false);
                bl_InDistance = false;
            }

            if (Vector3.Distance(go_WhereTo.transform.position, go_Player.transform.position) >= fl_Distance)
            {
                go_PressE.SetActive(false);
                bl_InDistance = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            bl_InDistance = true;
        }
    }
}