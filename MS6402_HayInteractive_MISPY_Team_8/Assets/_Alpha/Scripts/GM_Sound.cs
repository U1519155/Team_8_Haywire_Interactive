using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_Sound : MonoBehaviour {

    private AudioSource as_Source;
    public AudioClip ac_Audio;
    public GameObject go_activator;
    public float fl_distance;
    public float fl_timer = 2F;

    void Start()
    {
        //Reference to Source Component
        as_Source = GetComponent<AudioSource>();
        as_Source.clip = ac_Audio;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > fl_timer - 1)
            if (as_Source.isPlaying == false) as_Source.Play();
        if (Vector3.Distance(transform.position, go_activator.transform.position) > fl_distance)
        {
            as_Source.Stop();
        }
    }//--------
}
