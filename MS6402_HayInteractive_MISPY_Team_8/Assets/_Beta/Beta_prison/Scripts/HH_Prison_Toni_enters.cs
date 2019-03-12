using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HH_Prison_Toni_enters : MonoBehaviour
{
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
        if (other.gameObject.GetComponent<HH_prison_toniMove>())
        {

        }
    }
}
