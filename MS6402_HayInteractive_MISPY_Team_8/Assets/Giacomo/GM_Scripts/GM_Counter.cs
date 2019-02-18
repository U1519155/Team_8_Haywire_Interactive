using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class GM_Counter : MonoBehaviour
{
    Story currentStory;
    public GameObject inkController;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        currentStory = inkController.GetComponent<GM_BasicInk>().story;
        print(currentStory.variablesState["counter"]);
        if (Input.GetKeyDown("space"))
        {
            currentStory.variablesState["counter"] = 10;
        }
    }
}
