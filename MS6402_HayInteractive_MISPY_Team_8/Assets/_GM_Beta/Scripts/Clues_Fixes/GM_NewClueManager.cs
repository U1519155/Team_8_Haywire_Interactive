using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_NewClueManager : MonoBehaviour
{
    private bool bl_AnotherOne = true;
    private int in_Temp = 0;
    private int in_ToBeActive = 3;

    public GameObject[] SpheresClues;

    // Update is called once per frame
    void Update()
    {
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

                    if (in_Temp == 1)
                    {
                        go_Temp.tag = "Clue1";
                    }

                    if (in_Temp == 2)
                    {
                        go_Temp.tag = "Clue2";
                    }

                    if (in_Temp == 3)
                    {
                        go_Temp.tag = "Clue3";
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