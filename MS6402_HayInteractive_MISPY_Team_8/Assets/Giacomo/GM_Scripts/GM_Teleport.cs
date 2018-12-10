using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_Teleport : MonoBehaviour
{
    public static bool bl_Teleport;

    private GameObject go_Player;
    public Vector3 v3_PlayerPos;

	// Use this for initialization
	void Start ()
    {
        go_Player = GameObject.FindGameObjectWithTag("Player");
        v3_PlayerPos = go_Player.transform.position;
        bl_Teleport = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Debug.Log(bl_Teleport + "Hey baby");
		if (bl_Teleport == true)
        {
            go_Player.transform.position = new Vector3(v3_PlayerPos.x, v3_PlayerPos.y, v3_PlayerPos.z);
            bl_Teleport = false;
        }

	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
           // go_Player.transform.position = new Vector3(v3_PlayerPos.x, v3_PlayerPos.y, v3_PlayerPos.z);
        }
    }
}
