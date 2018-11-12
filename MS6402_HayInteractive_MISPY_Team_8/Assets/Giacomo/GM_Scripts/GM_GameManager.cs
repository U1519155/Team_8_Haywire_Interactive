using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GM_GameManager : MonoBehaviour
{
    public static bool bl_London;
    public static bool bl_Milan;
    public static bool bl_Dacca;
    public int in_Counter = 0;
    public Text txt_Counter;
    private bool bl_EndLevel = false;

	// Use this for initialization
	void Awake ()
    {
        DontDestroyOnLoad(gameObject);
	}

    void SetBools()
    {
        bl_London = false;
        bl_Dacca = false;
        bl_Milan = false;
        in_Counter = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {
        txt_Counter.text = "Suspicion Level: " + in_Counter;
    }

    public void London()
    {
        if (bl_London == true)
        {

        }

        else if (bl_London == false)
        {

        }
    }

    public void Milan()
    {
        if (bl_Milan == true)
        {

        }

        else if (bl_Milan == false)
        {

        }
    }

    public void Dacca()
    {
        if (bl_Dacca == true)
        {

        }

        else if (bl_Dacca == false)
        {

        }
    }
}