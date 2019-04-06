using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GM_ToSphere : MonoBehaviour
{
    //Variables
    public GameObject[] go_Buttons;
    public GameObject go_OtherClue1;
    public GameObject go_OtherClue2;
    public GameObject go_OtherClue3;
    public GameObject go_OtherClue4;

    [Header("WARNING: DO NOT ASSIGN go_ChosenClue TO ANYTHING.")]
    public GameObject go_ChosenButton;
    private bool bl_Done = false;
    private int in_Index;

    private void Start()
    {
        in_Index = Random.Range(0, go_Buttons.Length);
        go_ChosenButton = go_Buttons[in_Index];
        go_ChosenButton.SetActive(true);
    }

    private void Update()
    {
        if (bl_Done == false)
        {
            if (go_ChosenButton == go_OtherClue1.GetComponent<GM_ToSphere>().go_ChosenButton || go_ChosenButton == go_OtherClue2.GetComponent<GM_ToSphere>().go_ChosenButton || go_ChosenButton == go_OtherClue3.GetComponent<GM_ToSphere>().go_ChosenButton || go_ChosenButton == go_OtherClue4.GetComponent<GM_ToSphere>().go_ChosenButton)
            {
                go_ChosenButton.SetActive(false);
                ReDo();
            }

            else
            {
                bl_Done = true;
            }
        }
    } 

    private void ReDo()
    {
        in_Index = Random.Range(0, go_Buttons.Length);
        go_ChosenButton = go_Buttons[in_Index];
        go_ChosenButton.SetActive(true);
    }
}