using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GadgetManagerBehaviour : MonoBehaviour
{
    public GameObject GadgetMenuManager;

    public bool cigar = false, watch = false, bowtie = false;


    // Update is called once per frame
    void Update()
    {
        if (GadgetMenuManager != null)
        {
            cigar = GadgetMenuManager.GetComponent<GMenuButtonBehaviour>().selectedCigar;
            watch = GadgetMenuManager.GetComponent<GMenuButtonBehaviour>().selectedWatch;
            bowtie = GadgetMenuManager.GetComponent<GMenuButtonBehaviour>().selectedBowtie;
        }
        DontDestroyOnLoad(this);
        
    }
}
