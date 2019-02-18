using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Attach this to the Player

public class CodeGenerator : MonoBehaviour
{
    //Private Variables
    private string st_Value;
    private string st_First;
    private string st_Second;
    private string st_Third;
    private int in_First;
    private int in_Second;
    private int in_Third;
    private int in_Temp = 0;
    private int in_ToBeActive = 3;
    //private int in_ToSubtract = 2;
    private bool bl_AnotherOne = true;
    private bool bl_Value1 = false;
    private bool bl_Value2 = false;
    private bool bl_Value3 = false;
    //private GameObject go_Child;

    //Public Variables
    public GameObject[] SpheresClues;
    public GameObject go_Movable;
    [SerializeField]
    public static GameObject go_Keypad;
   // public static GameObject go_KeypadHolder;

    void Start()
    {
        go_Keypad = GameObject.Find("Keypad");
     //   go_KeypadHolder = GameObject.Find("KeypadHolder");
       // go_KeypadHolder.SetActive(false);

        // Generates the 3 digits for the code and translates it to a string. 
        in_First = Random.Range(0, 9);
        in_Second = Random.Range(0, 9);
        in_Third = Random.Range(0, 9);
        st_First = "Hi Larry. This is Jake. I just wanted to remind you that the first number is " + in_First.ToString() + ", so you will stop getting it wrong. Get a hold of yourself, man.";
        st_Second = "Sorry Marvin! I was out the whole day and the reception was really bad. Anyway, the second number is " + in_Second.ToString() + "! Sorry again. \nLove, Claire";
        st_Third = "Note to self: The third number of the code is " + in_Third.ToString() + ". \nGet Stacey from school at 14:00. \nBuy water and milk.";
        st_Value = in_First.ToString() + in_Second.ToString() + in_Third.ToString();
        Debug.Log(st_Value);

        //Gets the Text component in every gameObject. Adds one if it is missing.
        foreach (GameObject i in SpheresClues)
        {
            
            i.GetComponentInChildren<Text>(true);

            if (i.GetComponentInChildren<Text>(true) != true)
            {
                i.AddComponent<Text>();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (FindClues.bl_NearKeypad == true)
        {
          //  go_KeypadHolder.SetActive(true);
            if (Input.anyKeyDown)
            {
                go_Keypad.GetComponentInChildren<Text>().text = "" + Input.anyKeyDown;
                Debug.Log(go_Keypad.GetComponentInChildren<Text>().text);

                if (go_Keypad.GetComponentInChildren<Text>().text == st_Value)
                {
                    go_Movable.transform.position = new Vector3(1, 0, 0) * Time.deltaTime;
                }
            }
        }

        //Disables 2 of the 5 random locations for the digits to be spawned in. It gives each a digit. In order to work, the length
        //of the array has to be 5 and the text childed to the GameObjects has to be empty.
        if (bl_AnotherOne == true)
        {
            GameObject go_Temp;
            go_Temp = SpheresClues[Random.Range(0, SpheresClues.Length)];

            if (in_ToBeActive > in_Temp)
            {
                if (!go_Temp.activeInHierarchy)
                {
                    go_Temp.SetActive(true);
                    in_Temp++;

                    if (go_Temp.GetComponentInChildren<Text>(true).text == "")
                    {
                        if (bl_Value1 == false)
                        {
                            go_Temp.GetComponentInChildren<Text>(true).text = st_First;
                            bl_Value1 = true;
                            return;
                        }

                        else if (bl_Value2 == false)
                        {
                            go_Temp.GetComponentInChildren<Text>(true).text = st_Second;
                            bl_Value2 = true;
                            return;
                        }

                        else if (bl_Value3 == false)
                        {
                            go_Temp.GetComponentInChildren<Text>(true).text = st_Third;
                            bl_Value3 = true;
                            return;
                        }
                    }
                }
            }

            //Stops the function above.
            if (in_Temp == in_ToBeActive)
            {
                bl_AnotherOne = false;
            }
        }
    }

    //Activate or deactivate button that shows the text.
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Clue")
    //    {
    //        print("Clue!");
    //        go_Child = GameObject.Find("Button");            
    //        go_Child.SetActive(true);
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{

    //}
}

/*
    //Back-Up    
    //Enables 3 of the 5 random locations for the digits to be spawned in.
        if (bl_AnotherOne == true)
        {
            GameObject go_Temp;
go_Temp = SpheresClues[Random.Range(0, SpheresClues.Length)];

            if (in_Temp<in_ToSubtract)
            {
                if (go_Temp.activeInHierarchy)
                {
                    go_Temp.SetActive(false);
                    in_Temp++;
                }
            }

            if (in_Temp == in_ToSubtract)
            {
                bl_AnotherOne = false;
            }
        }*/