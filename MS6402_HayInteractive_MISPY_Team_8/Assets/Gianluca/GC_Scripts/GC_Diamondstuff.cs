using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GC_Diamondstuff : MonoBehaviour
{

    public GameObject go_player;
    public GameObject go_diamond;
    public GameObject go_endwithdiamond;
    public GameObject go_endnodiamond;

    public Text tx_take;
    [HideInInspector] public bool bl_doit;

    // Start is called before the first frame update
    void Start()
    {
        go_player = GameObject.FindGameObjectWithTag("Player");
        tx_take.text = "";
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == go_player)
        {
            tx_take.text = "ok";
            bl_doit=true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        tx_take.text = "";
        bl_doit = false;
    }

    private void Update()
    {
            if (Input.GetKeyDown(KeyCode.E))
            {
                go_diamond.SetActive(false);
                go_endnodiamond.SetActive(false);
                go_endwithdiamond.SetActive(true);
                tx_take.text = "boi";
            }
    }
}
