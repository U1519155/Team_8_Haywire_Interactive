using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    //Keeps track of all the sentences in the dialogue (FiFo collection: first in, first out). Good practice to define 
    //a type for the Queue Data type.
    private Queue<string> Q_sentences;

    //You will find these under the canvas.
    public Text txt_NameText;
    public Text txt_DialogueText;

    public Animator anmtr_Holder;

    // Start is called before the first frame update
    void Start()
    {
        //Initialise the queue.
        Q_sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        anmtr_Holder.SetBool("IsOpen", true);

        txt_NameText.text = dialogue.st_Name;

        //Clears all the previous sentences
        Q_sentences.Clear();

        //Let's queue up the sentences from the NPC.
        foreach(string sentence_Item in dialogue.st_Sentences)
        {
            Q_sentences.Enqueue(sentence_Item);
        }

        //Once queued, dysplay the first one.
        DisplayNextSentence();
    }

    //Make it public so we can call it from other scripts.
    public void DisplayNextSentence()
    {
        Debug.Log("DisplayMe");
        //Is there more sentences in the queue? If yes, trigger EndDialogue. If not, load the next one.
        if (Q_sentences.Count == 0)
        {
            EndDialogue();
            Debug.Log("Ended");
            return;
        }

        string single_Sentence = Q_sentences.Dequeue();
        txt_DialogueText.text = single_Sentence;
    }

    public void EndDialogue()
    {
        anmtr_Holder.SetBool("IsOpen", false);
    }
}

/*
    IEnumerator TypeSentence (string Sentence)
    {
        txt_DialogueText.text = "";

        //ToCharArray converts a string into a character array.
        foreach(char letter in Sentence.ToCharArray())
        {
            txt_DialogueText.text += letter;
            yield return null;
        }
    }
 */