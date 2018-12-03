using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_Teleport : MonoBehaviour
{

    public static bool bl_Teleport = false;
    private GameObject go_Player;
    private Vector3 v3_PlayerPos;

	// Use this for initialization
	void Start ()
    {
        go_Player = GameObject.FindGameObjectWithTag("Player");
        v3_PlayerPos = go_Player.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (bl_Teleport == true)
        {
            go_Player.transform.position = new Vector3(v3_PlayerPos.x , v3_PlayerPos.y ,v3_PlayerPos.z);
            bl_Teleport = false;
        }
	}
}
