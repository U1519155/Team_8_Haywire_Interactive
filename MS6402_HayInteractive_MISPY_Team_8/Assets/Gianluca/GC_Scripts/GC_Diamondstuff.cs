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
    public GameObject go_image;

    [HideInInspector] public bool bl_doit;

    // Start is called before the first frame update
    void Start()
    {
        go_player = GameObject.FindGameObjectWithTag("Player");
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == go_player)
        {
            go_image.SetActive(true);
            bl_doit=true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        go_image.SetActive(false);
        bl_doit = false;
    }

    private void Update()
    {
            if (Input.GetKeyDown(KeyCode.E))
            {
                go_diamond.SetActive(false);
                go_endnodiamond.SetActive(false);
                go_endwithdiamond.SetActive(true);
            go_image.SetActive(false);
            }
    }
}
