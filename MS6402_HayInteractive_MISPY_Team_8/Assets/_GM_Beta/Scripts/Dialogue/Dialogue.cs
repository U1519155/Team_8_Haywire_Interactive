using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The attribute System.Serializable allows the class to be edited in the inspector.
[System.Serializable]
public class Dialogue
{
    //Class used as an object to pass into the Dialogue Manager when starting a new dialogue. Hosts all info about a single dialogue.

    public string st_Name;

    //The TextArea attributes modifies how the array below shows up in the inspector. The two variables are, respectively, the minimum and
    //maximum number of lines the text areas in the inspector are going to use (how big they are).
    [TextArea(3,10)]
    public string[] st_Sentences;
}