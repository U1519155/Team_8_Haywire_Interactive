using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GC_Planning_manager : MonoBehaviour {

    public Text txt_variabletext;
    public Button next_button;
    private int in_counter;

    public GameObject[] go_pictures;                               //array because it's fancy
    //public GameObject go_map;
    //public GameObject go_id;
    //public GameObject go_go_gadget;                             //other possible way


    // Use this for initialization
    void Start () {
        in_counter = 0;                                         //variable to keep track of what stage of planning the player is at
        txt_variabletext.text = "Map of the level";             //first state
        next_button.onClick.AddListener(ClickAction);           //to activate the button functions
        go_pictures[1].SetActive(false);                        //hide gadgets and IDs
        go_pictures[2].SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        //go_pictures[in_counter].SetActive(true);
        if (in_counter <= 2)
        {
            Time.timeScale = 0;                                 //  <======== THIS IS WHAT IS CAUSING PROBLEMS PROBABLY
                                                                //it's here so that the PC isn't able to walk around when choosing ID and gadgets
        }
        else
        {
            txt_variabletext.text = "";                                   //hide UI text
            next_button.gameObject.SetActive(false);                        //remove button
            go_pictures[2].SetActive(false);                                //remove gadgets
            Time.timeScale = 1;                                             //reset normal timeflow
        }
    }

    void ClickAction ()
    {
        in_counter++;
        if (in_counter == 1)
        {
            txt_variabletext.text = "Select your ID";                       //second state
            go_pictures[0].SetActive(false);                                //hide map
            go_pictures[1].SetActive(true);                                 //show IDs
            
        }
        else
        {
            txt_variabletext.text = "Select your gadgets";                  //third state
            go_pictures[1].SetActive(false);                                //hide IDs
            go_pictures[2].SetActive(true);                                 //show gadgets
        }
        
        
    }
}
