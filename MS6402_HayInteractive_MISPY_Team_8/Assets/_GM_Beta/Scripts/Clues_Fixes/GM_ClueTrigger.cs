using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GM_ClueTrigger : MonoBehaviour
{
    private string st_Value;
    private string st_First;
    private string st_Second;
    private string st_Third;
    private int in_First;
    private int in_Second;
    private int in_Third;

    public GameObject go_ButtonClue;
    public GameObject go_Movable;
    public static GameObject go_Keypad;
    public static string st_PlayerInput;
    public static bool bl_TriggerKeypad = false;
    public static bool bl_PressEKeypad = false;
    public static bool bl_DisableGUI = false;

    // Start is called before the first frame update
    void Start()
    {
        go_Keypad = GameObject.Find("Keypad");

        // Generates the 3 digits for the code and translates it to a string. 
        in_First = Random.Range(0, 9);
        in_Second = Random.Range(0, 9);
        in_Third = Random.Range(0, 9);
        st_First = "Hi Larry. This is Jake. I just wanted to remind you that the first number is " + in_First.ToString() + ", so you will stop getting it wrong. Get a hold of yourself, man.";
        st_Second = "Sorry Marvin! I was out the whole day and the reception was really bad. Anyway, the second number is " + in_Second.ToString() + "! Sorry again. \nLove, Claire";
        st_Third = "Note to self: The third number of the code for the elevator at the first floor in the studio is " + in_Third.ToString() + ". \nGet Stacey from school at 14:00. \nBuy water and milk.";
        st_Value = in_First.ToString() + in_Second.ToString() + in_Third.ToString();
        Debug.Log(st_Value);
    }

    private void Update()
    {
        //If the code is correct, something happens, the code is resetted and sound is played.
        if (st_Value == st_PlayerInput)
        {
            st_PlayerInput = "";
            //Add sound.
            go_Movable.SetActive(false);
            DisableGUI();
        }

        //If the keypad exists in the scene and the collider is activated, make a GUI that says "Press E to open".
        if (bl_TriggerKeypad == true && go_Keypad.activeInHierarchy == true)
        {
            if (bl_PressEKeypad == false)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    bl_PressEKeypad = true;
                    GUI.enabled = false;
                }
            }

            //Makes a GUI after the player has pressed E. If the player clicks on the buttons or digits them on the keyboard, they show up in the GUI. The player can press R to reset the code.
            if (bl_PressEKeypad == true)
            {
                if (Input.GetKeyDown(KeyCode.R))
                {
                    st_PlayerInput = "";
                }

                if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
                {
                    st_PlayerInput = st_PlayerInput + "1";
                }

                if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
                {
                    st_PlayerInput = st_PlayerInput + "2";
                }

                if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
                {
                    st_PlayerInput = st_PlayerInput + "3";
                }

                if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
                {
                    st_PlayerInput = st_PlayerInput + "4";
                }

                if (Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Keypad5))
                {
                    st_PlayerInput = st_PlayerInput + "5";
                }

                if (Input.GetKeyDown(KeyCode.Alpha6) || Input.GetKeyDown(KeyCode.Keypad6))
                {
                    st_PlayerInput = st_PlayerInput + "6";
                }

                if (Input.GetKeyDown(KeyCode.Alpha7) || Input.GetKeyDown(KeyCode.Keypad7))
                {
                    st_PlayerInput = st_PlayerInput + "7";
                }

                if (Input.GetKeyDown(KeyCode.Alpha8) || Input.GetKeyDown(KeyCode.Keypad8))
                {
                    st_PlayerInput = st_PlayerInput + "8";
                }

                if (Input.GetKeyDown(KeyCode.Alpha9) || Input.GetKeyDown(KeyCode.Keypad9))
                {
                    st_PlayerInput = st_PlayerInput + "9";
                }

                if (Input.GetKeyDown(KeyCode.Alpha0) || Input.GetKeyDown(KeyCode.Keypad0))
                {
                    st_PlayerInput = st_PlayerInput + "0";
                }

                if (st_PlayerInput == st_Value)
                {
                    go_Movable.transform.position = new Vector3(1, 0, 0) * Time.deltaTime;
                    Invoke("DisableGUI", 3f);
                }
                // Add sound
            }
        }
    }

    private void OnGUI()
    {
        if (bl_PressEKeypad == false && bl_TriggerKeypad == true && go_Keypad.activeInHierarchy == true)
        {
            GUI.Box(new Rect(0, 0, 400, 50), "Press 'E' to open keypad");
        }

        if (bl_PressEKeypad == true)
        {
            GUI.Button(new Rect(5, 35, 100, 100), "1");
            GUI.Button(new Rect(110, 35, 100, 100), "2");
            GUI.Button(new Rect(215, 35, 100, 100), "3");
            GUI.Button(new Rect(5, 140, 100, 100), "4");
            GUI.Button(new Rect(110, 140, 100, 100), "5");
            GUI.Button(new Rect(215, 140, 100, 100), "6");
            GUI.Button(new Rect(5, 245, 100, 100), "7");
            GUI.Button(new Rect(110, 245, 100, 100), "8");
            GUI.Button(new Rect(215, 245, 100, 100), "9");
            GUI.Button(new Rect(110, 350, 100, 100), "0");

            GUI.Label(new Rect(10, 10, 200, 25), "Press R to restart");
            GUI.Box(new Rect(0, 0, 320, 455), "");
            GUI.Box(new Rect(5, 5, 310, 25), st_PlayerInput);
        }
    }

    //A void to disable permanently the GUI.
    private void DisableGUI()
    {
        bl_DisableGUI = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Keypad")
        {
            if (bl_DisableGUI == false)
            {
                bl_TriggerKeypad = true;
                bl_PressEKeypad = false;
            }
        }

        if (other.tag == "Clue1")
        {
            go_ButtonClue.SetActive(true);
            go_ButtonClue.GetComponentInChildren<Text>(true).text = st_First;
        }

        if (other.tag == "Clue2")
        {
            go_ButtonClue.SetActive(true);
            go_ButtonClue.GetComponentInChildren<Text>(true).text = st_Second;
        }

        if (other.tag == "Clue3")
        {
            go_ButtonClue.SetActive(true);
            go_ButtonClue.GetComponentInChildren<Text>(true).text = st_Third;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Clue1" || other.tag == "Clue2" || other.tag == "Clue3")
        {
            go_ButtonClue.SetActive(false);
        }

        if (other.tag == "Keypad")
        {
            bl_TriggerKeypad = false;
            bl_PressEKeypad = false;
            st_PlayerInput = "";
        }
    }
}