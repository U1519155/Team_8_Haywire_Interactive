using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeAndStore : MonoBehaviour
{
    //Attach this script to the trigger childed to the key.
    //Variables
    public GameObject go_PressE;
    public GameObject go_KeyRadio;
    private bool bl_InRange = false;
    public static bool bl_HasKey = false;
    private GameObject go_KeySprite;
    public AudioSource as_Source;
    public AudioClip Ac_TakeKey;

    private void Start()
    {
        go_KeySprite = GameObject.Find("Key_Sprite");
        go_KeySprite.SetActive(false);
        go_KeyRadio.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (bl_InRange == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                print("Taken");
                as_Source.clip = Ac_TakeKey;
                as_Source.Play();
                bl_HasKey = true;
                go_KeySprite.SetActive(true);
                go_PressE.SetActive(false);
                gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            go_PressE.SetActive(true);
            bl_InRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        bl_InRange = false;
        go_PressE.SetActive(false);
    }
}