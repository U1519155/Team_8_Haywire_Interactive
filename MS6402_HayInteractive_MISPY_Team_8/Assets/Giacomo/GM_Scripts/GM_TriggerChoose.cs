﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GM_TriggerChoose : MonoBehaviour
{
    // variables - Attach this script to a trigger childed in front of the pc
    public bool bl_Dhaka = false;
    public bool bl_London = false;
    public bool bl_Rome = false;
    public bool bl_Kayode = false;
    public bool bl_Kevin = false;
    public bool bl_Richard = false;
    public bool bl_Hamer = false;
    public bool bl_Mason = false;
    public bool bl_Shonibare = false;
    public bool bl_GameDesigner = false;
    public bool bl_MarineBiologist = false;
    public bool bl_Actor = false;
    public int in_IncreasedSuspicion = 1;

    //public GameObject go_TriggerQuestion;
    //public GameObject go_TriggerIdentity;
    public GameObject go_ButtonHolder;
    public GameObject go_QuestionMeHolder;
    public GameObject[] go_Questions;
    private int in_IndexQuestion;

	// Set the gameobjects that are parented to the buttons false at the start of the scene. Selects an initial index for the gamobject(parent of the buttons) that gets activated.
	void Start ()
    {
        go_ButtonHolder.SetActive(false);
        go_QuestionMeHolder.SetActive(false);
        in_IndexQuestion = Random.Range(0, go_Questions.Length);
	}

    private void Update()
    {
        if (GM_Suspicion.in_Suspicion <= 0)
        {
            GM_Suspicion.in_Suspicion = 0;
        }
    }

    // Set active if interacts with the button, deactivate if it exits
    public void OnTriggerEnter(Collider other)
    {
        
        Debug.Log("Inside");
        if (other.tag == "IdentityHolder")
        {
            go_ButtonHolder.SetActive(true);
        }

        if (other.tag == "QuestionHolder")
        {
            go_QuestionMeHolder.SetActive(true);
            go_Questions[in_IndexQuestion].SetActive(true);
            GM_Suspicion.bl_GuardTalk = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit");
        if (other.tag == "IdentityHolder")
        {
            go_ButtonHolder.SetActive(false);
        }

        if (other.tag == "QuestionHolder")
        {
            go_QuestionMeHolder.SetActive(false);
            go_Questions[in_IndexQuestion].SetActive(false);
            GM_Suspicion.bl_GuardTalk = false;
            SetIndex();
        }
    }

    void SetIndex()
    {
        in_IndexQuestion = Random.Range(0, go_Questions.Length);
    }

    // Identity choices: Identified by the ButtonHolder gameobject
    public void IDRichard()
    {
        Debug.Log("Clicked!");
        bl_Dhaka = true;
        bl_Richard = true;
        bl_Mason = true;
        bl_Actor = true;
        go_ButtonHolder.SetActive(false);
    }

    public void IDKevin()
    {
        Debug.Log("Clicked!");
        bl_London = true;
        bl_Kevin = true;
        bl_Shonibare = true;
        bl_MarineBiologist = true;
        go_ButtonHolder.SetActive(false);
    }

    public void IDKayode()
    {
        Debug.Log("Clicked!");
        bl_Rome = true;
        bl_Kayode = true;
        bl_Hamer = true;
        bl_GameDesigner = true;
        go_ButtonHolder.SetActive(false);
    }

    // Identity questions - Identified by the QuestionMeHolder gameobject. Increases or decreases suspicion.
    public void QuestionIDRichard()
    {
   
         if (bl_Dhaka == true)
         {
            Debug.Log("You can pass");
            GM_Suspicion.in_Suspicion = GM_Suspicion.in_Suspicion - in_IncreasedSuspicion;
            go_QuestionMeHolder.SetActive(false);
         }

         else if (bl_Dhaka == false)
         {
            Debug.Log("Dafuq");
            GM_Suspicion.in_Suspicion = GM_Suspicion.in_Suspicion + in_IncreasedSuspicion;
            go_QuestionMeHolder.SetActive(false);
         }
        
    }

    public void QuestionIDKevin()
    {

        if (bl_London == true)
        {
            Debug.Log("You can pass");
            GM_Suspicion.in_Suspicion = GM_Suspicion.in_Suspicion - in_IncreasedSuspicion;
            go_QuestionMeHolder.SetActive(false);
        }

        else if (bl_London == false)
        {
            Debug.Log("Dafuq");
            GM_Suspicion.in_Suspicion = GM_Suspicion.in_Suspicion + in_IncreasedSuspicion;
            go_QuestionMeHolder.SetActive(false);
        }

    }

    public void QuestionIDKayode()
    {

        if (bl_Rome == true)
        {
            Debug.Log("You can pass");
            GM_Suspicion.in_Suspicion = GM_Suspicion.in_Suspicion - in_IncreasedSuspicion;
            go_QuestionMeHolder.SetActive(false);
        }

        else if (bl_Rome == false)
        {
            Debug.Log("Dafuq");
            GM_Suspicion.in_Suspicion = GM_Suspicion.in_Suspicion + in_IncreasedSuspicion;
            go_QuestionMeHolder.SetActive(false);
        }
    }
}


// BackUp of this script
/*
 * using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GM_TriggerChoose : MonoBehaviour
{
    // variables - Attach this script to a trigger childed in front of the pc
    public bool bl_Dacca = false;
    public bool bl_London = false;
    public bool bl_Rome = false;
    public bool bl_Kayode = false;
    public bool bl_Kevin = false;
    public bool bl_Richard = false;
    public bool bl_Hamer = false;
    public bool bl_Mason = false;
    public bool bl_Shonibare = false;
    public bool bl_GameDesigner = false;
    public bool bl_MarineBiologist = false;
    public bool bl_ = false;

    public int in_IncreasedSuspicion = 1;

    public GameObject go_TriggerQuestion;
    public GameObject go_TriggerIdentity;
    public GameObject go_ButtonHolder;
    public GameObject go_QuestionMeHolder;

	// Set the gameobjects that are parented to the buttons false at the start of the scene
	void Start ()
    {
        go_ButtonHolder.SetActive(false);
        go_QuestionMeHolder.SetActive(false);
	}

    private void Update()
    {
        if (GM_Suspicion.in_Suspicion <= 0)
        {
            GM_Suspicion.in_Suspicion = 0;
        }
    }

    // Set active if interacts with the button, deactivate if it exits
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Inside");
        if (other.tag == "IdentityHolder")
        {
            go_ButtonHolder.SetActive(true);
        }

        if (other.tag == "QuestionHolder")
        {
            go_QuestionMeHolder.SetActive(true);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit");
        if (other.tag == "IdentityHolder")
        {
            go_ButtonHolder.SetActive(false);
        }

        if (other.tag == "QuestionHolder")
        {
            go_QuestionMeHolder.SetActive(false);
        }
    }

    // Identity choices: Identified by the ButtonHolder gameobject
    public void Dacca()
    {
        Debug.Log("Clicked!");
        bl_Dacca = true;
        Destroy(go_ButtonHolder);
    }

    public void London()
    {
        Debug.Log("Clicked!");
        bl_London = true;
        Destroy(go_ButtonHolder);
    }

    public void Rome()
    {
        Debug.Log("Clicked!");
        bl_Rome = true;
        Destroy(go_ButtonHolder);
    }

    // Identity questions - Identified by the QuestionMeHolder gameobject. Increases or decreases suspicion.
    public void QuestionDacca()
    {
   
         if (bl_Dacca == true)
         {
            Debug.Log("You can pass");
            GM_Suspicion.in_Suspicion = GM_Suspicion.in_Suspicion - in_IncreasedSuspicion;
            Destroy(go_QuestionMeHolder);
         }

         else if (bl_Dacca == false)
         {
            Debug.Log("Dafuq");
            GM_Suspicion.in_Suspicion = GM_Suspicion.in_Suspicion + in_IncreasedSuspicion;
            Destroy(go_QuestionMeHolder);
         }
        
    }

    public void QuestionLondon()
    {

        if (bl_London == true)
        {
            Debug.Log("You can pass");
            GM_Suspicion.in_Suspicion = GM_Suspicion.in_Suspicion - in_IncreasedSuspicion;
            Destroy(go_QuestionMeHolder);
        }

        else if (bl_London == false)
        {
            Debug.Log("Dafuq");
            GM_Suspicion.in_Suspicion = GM_Suspicion.in_Suspicion + in_IncreasedSuspicion;
            Destroy(go_QuestionMeHolder);
        }

    }

    public void QuestionRome()
    {

        if (bl_Rome == true)
        {
            Debug.Log("You can pass");
            GM_Suspicion.in_Suspicion = GM_Suspicion.in_Suspicion - in_IncreasedSuspicion;
            Destroy(go_QuestionMeHolder);
        }

        else if (bl_Rome == false)
        {
            Debug.Log("Dafuq");
            GM_Suspicion.in_Suspicion = GM_Suspicion.in_Suspicion + in_IncreasedSuspicion;
            Destroy(go_QuestionMeHolder);
        }
    }
}
*/