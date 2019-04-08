using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GC_Tonystuff : MonoBehaviour
{
    public GameObject go_player;
    public GameObject go_diamondtrigger;
    public GameObject go_endnodiamond;

    // Start is called before the first frame update
    void Start()
    {
        go_player = GameObject.FindGameObjectWithTag("Player");
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other == go_player)
        {
            go_diamondtrigger.SetActive(false);
            go_endnodiamond.SetActive(true);
        }
    }
}
