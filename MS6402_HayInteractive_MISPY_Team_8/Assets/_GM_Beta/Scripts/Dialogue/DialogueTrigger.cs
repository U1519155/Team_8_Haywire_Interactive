using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    //Put this on NPCs' childed trigger.
    //public GameObject go_Player;
    public Dialogue C_Dialogue;
    //public float fl_Distance = 12f;
    public float fl_TimerNextSentence = 5f;
    public static bool bl_End = false;
    private AudioSource as_Source;
    public AudioClip ac_Clip;
    //private bool bl_InRadius = false;

    //private void Update()
    //{
    //    Debug.Log(bl_End);
    //    if (bl_End == true)
    //    {

    //    }
    //}

    private void Start()
    {
        as_Source = gameObject.GetComponent<AudioSource>();

        as_Source.clip = ac_Clip;

        if (as_Source == null)
        {
            Debug.Log("GuardNeedsAudioSource!");
        }
    }

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
        as_Source.PlayOneShot(ac_Clip);
        yield return new WaitForSeconds(fl_TimerNextSentence);
        FindObjectOfType<DialogueManager>().DisplayNextSentence();
        as_Source.PlayOneShot(ac_Clip);
        yield return new WaitForSeconds(fl_TimerNextSentence);
        FindObjectOfType<DialogueManager>().DisplayNextSentence();
        as_Source.PlayOneShot(ac_Clip);
        yield return new WaitForSeconds(fl_TimerNextSentence);
        FindObjectOfType<DialogueManager>().DisplayNextSentence();
        as_Source.PlayOneShot(ac_Clip);
        yield return new WaitForSeconds(fl_TimerNextSentence);
        FindObjectOfType<DialogueManager>().DisplayNextSentence();
        as_Source.PlayOneShot(ac_Clip);
        yield return new WaitForSeconds(fl_TimerNextSentence);
        FindObjectOfType<DialogueManager>().DisplayNextSentence();
        as_Source.PlayOneShot(ac_Clip);
        yield return new WaitForSeconds(fl_TimerNextSentence);
        FindObjectOfType<DialogueManager>().DisplayNextSentence();
        as_Source.PlayOneShot(ac_Clip);
        yield return new WaitForSeconds(fl_TimerNextSentence);
        FindObjectOfType<DialogueManager>().DisplayNextSentence();
        as_Source.PlayOneShot(ac_Clip);
        yield return new WaitForSeconds(fl_TimerNextSentence);
        FindObjectOfType<DialogueManager>().DisplayNextSentence();
        as_Source.PlayOneShot(ac_Clip);
        yield return new WaitForSeconds(fl_TimerNextSentence);
        FindObjectOfType<DialogueManager>().DisplayNextSentence();
        as_Source.PlayOneShot(ac_Clip);
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

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            //bl_End = false;
            FindObjectOfType<DialogueManager>().EndDialogue();
            StopAllCoroutines();
        }
    }

    //If in fl_Radius, start the coroutine. If not, stop all coroutines and end dialogue.
    /*private void Update()
    {
        if (Vector3.Distance(gameObject.transform.position, go_Player.transform.position) <= fl_Distance)
        {
            TriggerDialogue();
            StartCoroutine(KeepTalking());
        }

        else if (Vector3.Distance(gameObject.transform.position, go_Player.transform.position) > fl_Distance)
        {
            C_Manager.EndDialogue();
            StopAllCoroutines();
            in_OneLimit = 0;
        }
    } */
}