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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == go_player)
        {
            Debug.Log("PC in trigger");
            bl_pcinrange = true;
            v_position = other.transform.position;
        }
    }
}
