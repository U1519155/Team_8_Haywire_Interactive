using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CaughtCounter;

public class HH_Prison_Trigger : MonoBehaviour
{
    public bool Escaped;
    

    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.GetComponent<CharacterController>())
        {
           // HH_Prison_GameManager.hasEscaped = true;
            
        }
    }
}
