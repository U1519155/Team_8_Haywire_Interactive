using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_TriggerInk : MonoBehaviour
{

    public GameObject go_InkScriptController;


    private void OnTriggerEnter(Collider other)
    {
        go_InkScriptController.GetComponent<GM_BasicInk>().StartStoryOnButtonPress();
    }
    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
