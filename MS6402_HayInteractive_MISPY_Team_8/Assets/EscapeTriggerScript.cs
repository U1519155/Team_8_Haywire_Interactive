using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CaughtCounter;

public class EscapeTriggerScript : MonoBehaviour
{
    public GameObject GameManager;

    public void Start()
    {
        GameManager = GameObject.FindGameObjectWithTag("Prison_gameManger");
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterController>())
        {
            GameManager.GetComponent<HH_Prison_GameManager>().hasEscaped = true;
        }
    }
}
