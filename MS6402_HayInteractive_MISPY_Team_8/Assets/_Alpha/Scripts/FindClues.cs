using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FindClues : MonoBehaviour
{
    private GameObject go_Child = null;

    public static bool bl_NearKeypad = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Clue")
        {
            go_Child = other.GetComponentInChildren<Button>(true).gameObject;

            if (go_Child == null && !go_Child.activeInHierarchy)
            {
                Debug.Log("Clue No Childed object");
            }

            go_Child.SetActive(true);
        }

        if (other.tag == "Keypad")
        {
            bl_NearKeypad = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Clue")
        {
            if (go_Child != null && go_Child.activeInHierarchy)
            {
                go_Child.SetActive(false);
            }
        }

        if (other.tag == "Keypad")
        {
            bl_NearKeypad = false;
            CodeGenerator.go_Keypad.GetComponentInChildren<Text>().text = "";
        }
    }
}