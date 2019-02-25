using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GC_Teleport : MonoBehaviour
{
    public GameObject destination;
    // Start is called before the first frame update

    public void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.GetComponent<CharacterController>())
        {
            other.gameObject.transform.position = destination.transform.position;
        }
    }

}
