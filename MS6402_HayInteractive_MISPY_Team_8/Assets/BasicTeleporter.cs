using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTeleporter : MonoBehaviour
{
    public Transform endPoint;

    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterController>())
        {

            other.transform.position = endPoint.position;

        }
    }
}

  
