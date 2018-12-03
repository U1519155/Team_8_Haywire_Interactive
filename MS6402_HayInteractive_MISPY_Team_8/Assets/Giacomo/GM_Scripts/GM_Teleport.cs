using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_Teleport : MonoBehaviour
{
<<<<<<< HEAD

    public static bool bl_Teleport;
=======
>>>>>>> 26c206e2455f5724d18ae3c4682963032e031f14
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
<<<<<<< HEAD
        Debug.Log(bl_Teleport + "Hey baby");
		if (bl_Teleport == true)
=======

	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
>>>>>>> 26c206e2455f5724d18ae3c4682963032e031f14
        {
            go_Player.transform.position = new Vector3(v3_PlayerPos.x, v3_PlayerPos.y, v3_PlayerPos.z);
        }
    }
}
