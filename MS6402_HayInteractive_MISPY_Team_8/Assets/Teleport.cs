using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject destination;
    GameObject dialogueBox;
    public GameObject player;
    public GameObject selftalk;


    // Start is called before the first frame update
    void Start()
    {
        dialogueBox = gameObject;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            gameObject.transform.position = destination.transform.position;
            selftalk.SetActive(true);
        }
    }

}
