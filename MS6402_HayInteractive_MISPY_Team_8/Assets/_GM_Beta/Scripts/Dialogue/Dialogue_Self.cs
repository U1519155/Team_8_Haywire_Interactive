using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue_Self : MonoBehaviour
{
    //Put this on NPCs' childed trigger.
    //public GameObject go_Player;
    public Dialogue C_Dialogue;
    //public float fl_Distance = 12f;
    public float fl_TimerNextSentence = 5f;
    public static bool bl_End = false;
    //private bool bl_InRadius = false;

    //private void Update()
    //{
    //    Debug.Log(bl_End);
    //    if (bl_End == true)
    //    {

    //    }
    //}

    //Finds and triggers the dialogue.
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(C_Dialogue);
    }

    //Wait for fl_Timer before loading the next sentence.
    IEnumerator KeepTalking()
    {
        yield return new WaitForSeconds(fl_TimerNextSentence);
        FindObjectOfType<DialogueManager>().DisplayNextSentence();
        yield return new WaitForSeconds(fl_TimerNextSentence);
        FindObjectOfType<DialogueManager>().DisplayNextSentence();
        yield return new WaitForSeconds(fl_TimerNextSentence);
        FindObjectOfType<DialogueManager>().DisplayNextSentence();
        yield return new WaitForSeconds(fl_TimerNextSentence);
        FindObjectOfType<DialogueManager>().DisplayNextSentence();
        yield return new WaitForSeconds(fl_TimerNextSentence);
        FindObjectOfType<DialogueManager>().DisplayNextSentence();
        yield return new WaitForSeconds(fl_TimerNextSentence);
        FindObjectOfType<DialogueManager>().DisplayNextSentence();
        yield return new WaitForSeconds(fl_TimerNextSentence);
        FindObjectOfType<DialogueManager>().DisplayNextSentence();
        yield return new WaitForSeconds(fl_TimerNextSentence);
        FindObjectOfType<DialogueManager>().DisplayNextSentence();
        yield return new WaitForSeconds(fl_TimerNextSentence);
        FindObjectOfType<DialogueManager>().DisplayNextSentence();
        yield return new WaitForSeconds(fl_TimerNextSentence);
        FindObjectOfType<DialogueManager>().DisplayNextSentence();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //bl_End = true;
            TriggerDialogue();
            StartCoroutine(KeepTalking());
        }
    }
}