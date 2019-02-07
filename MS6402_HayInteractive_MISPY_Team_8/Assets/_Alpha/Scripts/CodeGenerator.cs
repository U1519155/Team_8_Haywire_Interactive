using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private bool bl_AnotherOne = true;


    //Public Variables
    public GameObject[] SpheresClues;

    // Generated the 3 digits for the code and translates it to a string. 
    void Start()
    {
        in_First = Random.Range(0, 9);
        in_Second = Random.Range(0, 9);
        in_Third = Random.Range(0, 9);
        st_First = in_First.ToString();
        st_Second = in_Second.ToString();
        st_Third = in_Third.ToString();
        st_Value = st_First + st_Second + st_Third;
    }

    // Update is called once per frame
    void Update()
    {
        //Enables 3 of the 5 random locations for the digits to be spawned in.
        if (bl_AnotherOne == true)
        {
            GameObject go_Temp;
            go_Temp = SpheresClues[Random.Range(0, SpheresClues.Length)];

            if (in_Temp < 2)
            {
                if (go_Temp.activeInHierarchy)
                {
                    go_Temp.SetActive(false);
                    in_Temp++;
                }
            }

            if (in_Temp == 2)
            {
                bl_AnotherOne = false;
            }
        }
    }
}