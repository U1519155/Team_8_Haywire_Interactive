using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GC_IDdoor : MonoBehaviour
{
    public int in_ID;
    public float fl_opendistance = 3;
    public string st_PCtag = "MainCamera";
    [HideInInspector] public GameObject go_PC;

    // Start is called before the first frame update
    void Start()
    {
        go_PC = GameObject.FindGameObjectWithTag(st_PCtag);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(gameObject.transform.position, go_PC.transform.position) < fl_opendistance)
            //check distance
            if (go_PC.GetComponent<CameraController>().in_PCcurrentID == in_ID)
                //check if the ID is right 
            {
                //do the thing, play the anymation, whatever
                gameObject.SetActive(false);
            }
    }
}
