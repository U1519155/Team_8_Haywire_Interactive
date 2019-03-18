using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GC_TriggerAI : MonoBehaviour
{

    public Vector3 v_position;
    public bool bl_pcinrange;
    public GameObject go_player;

    // Start is called before the first frame update
    void Start()
    {
        go_player = GameObject.FindGameObjectWithTag("Player"); 
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == go_player)
        {
            //Debug.Log("PC in trigger")
            bl_pcinrange = true;
            v_position = go_player.transform.position;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == go_player)
        {
            bl_pcinrange = false;
            v_position=  Vector3.zero;
        }
    }
}
