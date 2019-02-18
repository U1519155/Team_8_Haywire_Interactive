using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_Trigger2 : MonoBehaviour
{
    public GameObject go_InkScriptController;
    [SerializeField] private TextAsset inkFile;


    private void OnTriggerEnter(Collider other)
    {
        go_InkScriptController.GetComponent<GM_BasicInk>().StartStoryOnTrigger(inkFile);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
