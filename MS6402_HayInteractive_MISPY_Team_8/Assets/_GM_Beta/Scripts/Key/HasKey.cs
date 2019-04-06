using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasKey : MonoBehaviour
{
    private bool bl_RotateDoor = false;
    public GameObject go_PressE;
    public GameObject go_NeedKey;
    private GameObject go_KitchenDoor;
    private GameObject go_Rotated;
    private GameObject go_Key_Sprite;
    public static bool bl_Open = false;
    public AudioSource as_Source;
    public AudioClip Ac_OpenDoor;
    //Attach this to a collider childed to the door. Tag the parent door as KitchenDoor.

    // Start is called before the first frame update
    void Start()
    {
        go_KitchenDoor = GameObject.Find("KitchenDoor");
        go_Rotated = GameObject.Find("KitchenDoorRotated");
        go_Key_Sprite = GameObject.Find("Key_Sprite");
        go_Rotated.SetActive(false);
        go_NeedKey.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (bl_RotateDoor == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                as_Source.clip = Ac_OpenDoor;
                as_Source.Play();
                Debug.Log("Open");
                bl_Open = true;
                go_Key_Sprite.SetActive(false);
                go_KitchenDoor.SetActive(false);
                go_Rotated.SetActive(true);
                gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (TakeAndStore.bl_HasKey == true)
            {
                bl_RotateDoor = true;
                go_PressE.SetActive(true);
            }

            else if (TakeAndStore.bl_HasKey == false)
            {
                go_NeedKey.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        bl_RotateDoor = false;
        go_PressE.SetActive(false);
        go_NeedKey.SetActive(false);
    }
}