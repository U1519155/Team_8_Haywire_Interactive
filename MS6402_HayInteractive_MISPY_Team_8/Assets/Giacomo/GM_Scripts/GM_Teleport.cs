using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_Teleport : MonoBehaviour
{
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

	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            go_Player.transform.position = new Vector3(v3_PlayerPos.x, v3_PlayerPos.y, v3_PlayerPos.z);
        }
    }
}
