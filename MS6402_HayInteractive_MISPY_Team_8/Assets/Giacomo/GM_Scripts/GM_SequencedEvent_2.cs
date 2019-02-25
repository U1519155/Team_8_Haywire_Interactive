using UnityEngine;

public class GM_SequencedEvent_2 : MonoBehaviour
{

    //Public Variables
    [Header("----Audio Clip----")]
    public AudioClip ac_Wrong;
    public AudioClip ac_Success;
    public AudioClip ac_Right;
<<<<<<< HEAD
    public AudioClip ac_OpenDoorSound;    
    public static GameObject go_PressE;

=======
    public AudioClip ac_OpenDoorSound;
    
    public static GameObject go_PressE;
>>>>>>> 465e6ad7cce271917b2d8b1451a80d5e2f16c400
    [Header("----buttons----")]
    public GameObject go_1Button;
    public GameObject go_2Button;
    public GameObject go_3Button;
    public GameObject go_4Button;
    public GameObject go_Block;
    [Header("----Materials----")]
    public Material m_Button1;
    public Material m_Button2;
    public Material m_Button3;
    public Material m_Button4;
    public static bool bl_1Button = false;
    public static bool bl_2Button = false;
    public static bool bl_3Button = false;
    public static bool bl_4Button = false;
    public static bool bl_In1Button = false;
    public static bool bl_In2Button = false;
    public static bool bl_In3Button = false;
    public static bool bl_In4Button = false;

    //Private Variables
    private AudioSource as_AudioSource;
    
    //---------------------------------------------------------------------

    void Start()
    {
        as_AudioSource = GetComponent<AudioSource>(); 

        go_PressE = GameObject.Find("Press_E");

        if (go_PressE == null)
        {
            Debug.Log("Press_E not found");
        }

        go_PressE.SetActive(false);

        go_1Button.GetComponent<Renderer>().material = m_Button1;
        go_2Button.GetComponent<Renderer>().material = m_Button2;
        go_3Button.GetComponent<Renderer>().material = m_Button3;
        go_4Button.GetComponent<Renderer>().material = m_Button4;
    }

    // If the booleans are true, their colour changes from red to green.
    void Update()
    {
        if (bl_1Button == true)
        {
            m_Button1.color = Color.green;
        }

        if (bl_1Button == false)
        {
            m_Button1.color = Color.red;
        }

        if (bl_2Button == true)
        {
            m_Button2.color = Color.green;
        }

        if (bl_2Button == false)
        {
            m_Button2.color = Color.red;
        }

        if (bl_3Button == true)
        {
            m_Button3.color = Color.green;
        }

        if (bl_3Button == false)
        {
            m_Button3.color = Color.red;
        }

        if (bl_4Button == true)
        {
            m_Button4.color = Color.green;
        }

        if (bl_4Button == false)
        {
            m_Button4.color = Color.red;
        }

        //If the correct order is followed, the buttons turn green and finally something happens. Otherwise, the buttons turn red and they are resetted.
        if (bl_In1Button == true)
        {
            if (Input.GetKeyDown("e"))
            {
                bl_1Button = true;
                as_AudioSource.clip = ac_Right;
                as_AudioSource.PlayOneShot(as_AudioSource.clip);
                go_PressE.SetActive(false);
            }
        }

        if (bl_In2Button == true)
        {
            if (Input.GetKeyDown("e"))
            {
                if (bl_1Button == true)
                {
                    bl_2Button = true;
                    as_AudioSource.clip = ac_Right;
                    as_AudioSource.PlayOneShot(as_AudioSource.clip);
                    go_PressE.SetActive(false);
                }

                else if (bl_1Button == false)
                {
                    as_AudioSource.clip = ac_Wrong;
                    as_AudioSource.PlayOneShot(as_AudioSource.clip);
                    go_PressE.SetActive(false);
                }
            }
        }

        if (bl_In3Button == true)
        {
            if (Input.GetKeyDown("e"))
            {
                if (bl_1Button == true && bl_2Button == true)
                {
                    bl_3Button = true;
                    as_AudioSource.clip = ac_Right;
                    as_AudioSource.PlayOneShot(as_AudioSource.clip);
                    go_PressE.SetActive(false);
                }

                else if (bl_1Button == false || bl_2Button == false)
                {
                    bl_2Button = false;
                    bl_1Button = false;
                    as_AudioSource.clip = ac_Wrong;
                    as_AudioSource.PlayOneShot(as_AudioSource.clip);
                    go_PressE.SetActive(false);
                }
            }
        }

        if (bl_In4Button == true)
        {
            if (Input.GetKeyDown("e"))
            {
                if (bl_1Button == true && bl_2Button == true && bl_3Button == true)
                {
                    bl_4Button = true;
                    OpenDoor();
                    as_AudioSource.clip = ac_OpenDoorSound;
                    as_AudioSource.PlayOneShot(as_AudioSource.clip);
                    go_PressE.SetActive(false);
                }

                else if (bl_1Button == false || bl_2Button == false || bl_3Button == false)
                {
                    bl_1Button = false;
                    bl_2Button = false;
                    bl_3Button = false;
                    as_AudioSource.clip = ac_Wrong;
                    as_AudioSource.PlayOneShot(as_AudioSource.clip);
                    go_PressE.SetActive(false);
                }
            }
        }
    }

    //If the sequence is followed correctly, something happens.
    void OpenDoor()
    {
        go_Block.SetActive(false);
        as_AudioSource.clip = ac_Success;
        as_AudioSource.PlayOneShot(as_AudioSource.clip);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Button1")
        {
            bl_In1Button = true;
            go_PressE.SetActive(true);
        }

        if (other.tag == "Button2")
        {
            bl_In2Button = true;
            go_PressE.SetActive(true);
        }

        if (other.tag == "Button3")
        {
            bl_In3Button = true;
            go_PressE.SetActive(true);
        }

        if (other.tag == "Button4")
        {
            bl_In4Button = true;
            go_PressE.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        bl_In1Button = false;
        bl_In2Button = false;
        bl_In3Button = false;
        bl_In4Button = false;
        bl_In1Button = false;
        go_PressE.SetActive(false);
    }
}