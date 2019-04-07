using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_ShowUp : MonoBehaviour
{
    public GameObject go_Monitor;
    public GameObject go_Napkin;
    public GameObject go_Paperwork;

    // Start is called before the first frame update
    void Start()
    {
        go_Monitor.SetActive(false);
        go_Napkin.SetActive(false);
        go_Paperwork.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Paperwork")
        {
            go_Paperwork.SetActive(true);
        }

        if (other.tag == "Napkin")
        {
            go_Napkin.SetActive(true);
        }

        if (other.tag == "Monitor")
        {
            go_Monitor.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Paperwork")
        {
            go_Paperwork.SetActive(false);
        }

        if (other.tag == "Napkin")
        {
            go_Napkin.SetActive(false);
        }

        if (other.tag == "Monitor")
        {
            go_Monitor.SetActive(false);
        }
    }
}