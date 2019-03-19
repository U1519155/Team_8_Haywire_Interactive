using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue_Characters : MonoBehaviour
{
    // This is a script to attach to an empty GameObject. It will create the ambience of people talking in the background.
    //Variables
    public GameObject go_Player;
    public float fl_Distance = 12f;
    public AudioClip ac_Audio;
    private AudioSource as_Source;
    private float fl_Timer = 2f;
    public float fl_Fading = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        as_Source = GetComponent<AudioSource>();
        as_Source.clip = ac_Audio;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > fl_Timer - 1)
        {
            if (as_Source.isPlaying == false)
            {
                as_Source.Play();
            }
        }

        if (Vector3.Distance(transform.position, go_Player.transform.position) > fl_Distance)
        {
            StartCoroutine(FadeOut(as_Source, fl_Fading));
        }
    }

    public static IEnumerator FadeOut(AudioSource audioSource, float fl_FadeTime)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / fl_FadeTime;

            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = startVolume;
    }
}