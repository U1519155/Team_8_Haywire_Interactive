using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CaughtCounter;

public class GM_ChooseTutorial : MonoBehaviour
{
    //@Hassan you should lock the character's movement OnTriggerEnter, and then unlock the PC on the ID voids and the Question voids.
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
    public GameObject go_Player;
    public GameObject go_Forward;
    public GameObject go_Back;

//public GameObject go_TriggerQuestion;
//public GameObject go_TriggerIdentity;
//public GameObject go_Door;
public GameObject go_ButtonHolder;
public GameObject go_QuestionMeHolder;
public GameObject[] go_Questions;
private int in_IndexQuestion;
private bool bl_IDChosen = false;

// //More variables LoL
// private Quaternion Q_CameraPC;
// private Quaternion Q_Cameraparent;
// private bool bl_IsFixed = false;
// public Camera cam_Camera;
// public GameObject go_PC;

// Set the gameobjects that are parented to the buttons false at the start of the scene. Selects an initial index for the gamobject(parent of the buttons) that gets activated.
private void Start()
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
    //if (bl_IsFixed == true)
    //{
    //    cam_Camera.transform.rotation = Q_CameraPC;
    //    go_PC.transform.rotation = Q_Cameraparent;
    //}
}

// Set active if interacts with the button, deactivate if it exits
public void OnTriggerEnter(Collider other)
{
    if (other.tag == "IdentityHolder")
    {
        if (bl_IDChosen == false)
        {
            go_ButtonHolder.SetActive(true);
            gameObject.GetComponentInParent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false;
            bl_IDChosen = true;
        }

        else if (bl_IDChosen == true)
        {

        }
        //Time.timeScale = 0;
        //bl_IsFixed = true;
        // Q_CameraPC = cam_Camera.transform.rotation;
        // Q_Cameraparent = go_PC.transform.rotation;
    }

    if (other.tag == "QuestionHolder")
    {
        go_QuestionMeHolder.SetActive(true);
        go_Questions[in_IndexQuestion].SetActive(true);
        GM_Suspicion.bl_GuardTalk = true;
        gameObject.GetComponentInParent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false;
        //Time.timeScale = 0;
        //bl_IsFixed = true;
        // Q_CameraPC = cam_Camera.transform.rotation;
        // Q_Cameraparent = go_PC.transform.rotation;

        // if (other.gameObject.name == "Questions_Holder")
        // {
        //     if (gameObject.GetComponent<Rigidbody>())
        //     {
        //         gameObject.transform.parent.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationY;
        //     }
        //
        //     else
        //     {
        //         print("No Rigidbody on PC");
        //     }
        // }
        //
        // else
        // {
        //     print("Security not found");
        // }
    }

    if (other.tag == "RandomQuestion")
    {
        int Number = Random.Range(0, 100);

        if (Number <= 50)
        {
            go_QuestionMeHolder.SetActive(true);
            go_Questions[in_IndexQuestion].SetActive(true);
            GM_Suspicion.bl_GuardTalk = true;
            gameObject.GetComponentInParent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false;
        }
    }
}

public void OnTriggerExit(Collider other)
{
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

    if (other.tag == "RandomQuestion")
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
    gameObject.GetComponentInParent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true;
    Debug.Log("Clicked!");
    bl_Dhaka = true;
    bl_Richard = true;
    bl_Mason = true;
    bl_Actor = true;
    go_ButtonHolder.SetActive(false);
    //Time.timeScale = 1;
}

public void IDKevin()
{
    gameObject.GetComponentInParent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true;
    Debug.Log("Clicked!");
    bl_London = true;
    bl_Kevin = true;
    bl_Shonibare = true;
    bl_MarineBiologist = true;
    go_ButtonHolder.SetActive(false);
    //Time.timeScale = 1;
}

public void IDKayode()
{
    gameObject.GetComponentInParent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true;
    Debug.Log("Clicked!");
    bl_Rome = true;
    bl_Kayode = true;
    bl_Hamer = true;
    bl_GameDesigner = true;
    go_ButtonHolder.SetActive(false);
    //Time.timeScale = 1;
}

// Identity questions - Identified by the QuestionMeHolder gameobject. Increases or decreases suspicion.
public void QuestionIDRichard()
{

    if (bl_Dhaka == true)
    {
        Debug.Log("You can pass");
        GM_Suspicion.in_Suspicion = GM_Suspicion.in_Suspicion - in_IncreasedSuspicion;
        go_QuestionMeHolder.SetActive(false);
        gameObject.GetComponentInParent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true;
            go_Player.transform.position = go_Forward.transform.position;
            // if (go_Door.activeInHierarchy == true)
            //   {
            //this.gameObject.SetActive(false);
            //       go_Door.SetActive(false);
            //    }
        }

    else if (bl_Dhaka == false)
    {
        Debug.Log("Dafuq");
        GM_Suspicion.in_Suspicion = GM_Suspicion.in_Suspicion + in_IncreasedSuspicion;
        go_QuestionMeHolder.SetActive(false);
            //     this.gameObject.SetActive(false);
            go_Player.transform.position = go_Back.transform.position;
            gameObject.GetComponentInParent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true;
    }

}

public void QuestionIDKevin()
{

    if (bl_London == true)
    {
        Debug.Log("You can pass");
        GM_Suspicion.in_Suspicion = GM_Suspicion.in_Suspicion - in_IncreasedSuspicion;
        go_QuestionMeHolder.SetActive(false);
        gameObject.GetComponentInParent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true;
            go_Player.transform.position = go_Forward.transform.position;
            //        if (go_Door.activeInHierarchy == true)
            //       {
            //            this.gameObject.SetActive(false);
            //            go_Door.SetActive(false);
            //        }
        }

    else if (bl_London == false)
    {
        Debug.Log("Dafuq");
        GM_Suspicion.in_Suspicion = GM_Suspicion.in_Suspicion + in_IncreasedSuspicion;
        go_QuestionMeHolder.SetActive(false);
            //        this.gameObject.SetActive(false);
            go_Player.transform.position = go_Back.transform.position;
            gameObject.GetComponentInParent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true;
    }

}

public void QuestionIDKayode()
{

    if (bl_Rome == true)
    {
        Debug.Log("You can pass");
        GM_Suspicion.in_Suspicion = GM_Suspicion.in_Suspicion - in_IncreasedSuspicion;
        go_QuestionMeHolder.SetActive(false);
        gameObject.GetComponentInParent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true;
            go_Player.transform.position = go_Forward.transform.position;
            //      if (go_Door.activeInHierarchy == true)
            //      {
            //           go_Door.SetActive(false);
            //           this.gameObject.SetActive(false);

            //      }
        }

    else if (bl_Rome == false)
    {
        Debug.Log("Dafuq");
        GM_Suspicion.in_Suspicion = GM_Suspicion.in_Suspicion + in_IncreasedSuspicion;
        go_QuestionMeHolder.SetActive(false);
            //     this.gameObject.SetActive(false);
            go_Player.transform.position = go_Back.transform.position;
            gameObject.GetComponentInParent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true;
    }
}
}
