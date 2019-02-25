using UnityEngine;
using UnityEngine.UI;

public class FindClues : MonoBehaviour
{
    //Variables
    private GameObject go_Child = null;

    //If the player detects a clue, the clue in the canvas shows up. If they detect the keypad, it makes the GUI show up. Once the right code is insterted in the keypad, the GUI won't be 
    //interactible anymore.
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
            if (CodeGenerator.bl_DisableGUI == false)
            {
                CodeGenerator.bl_TriggerKeypad = true;
                CodeGenerator.bl_PressEKeypad = true;
            }
        }

        // The following 4 if statements are for the SequencedEvents script. Tags needed = Button1 - Button2 - Button3 - Button4.
        if (other.tag == "Button1")
        {
            GM_SequencedEvent_2.go_PressE.SetActive(true);
            GM_SequencedEvent_2.bl_In1Button = true;
        }

        if (other.tag == "Button2")
        {
            GM_SequencedEvent_2.go_PressE.SetActive(true);
            GM_SequencedEvent_2.bl_In2Button = true;
        }

        if (other.tag == "Button3")
        {
            GM_SequencedEvent_2.go_PressE.SetActive(true);
            GM_SequencedEvent_2.bl_In3Button = true;
        }

        if (other.tag == "Button4")
        {
            GM_SequencedEvent_2.go_PressE.SetActive(true);
            GM_SequencedEvent_2.bl_In4Button = true;
        }

    }

    //If the player leaves the area where the collider is, any clue and the keypad's GUI disappear.
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
            CodeGenerator.bl_TriggerKeypad = false;
            CodeGenerator.bl_PressEKeypad = false;
            CodeGenerator.st_PlayerInput = "";
        }

        //Sequenced Event functions
        //GM_SequencedEvent_2.go_PressE.SetActive(false);
        //GM_SequencedEvent_2.bl_In1Button = false;
        //GM_SequencedEvent_2.bl_In4Button = false;
        //GM_SequencedEvent_2.bl_In2Button = false;
        //GM_SequencedEvent_2.bl_In3Button = false;
    }
}