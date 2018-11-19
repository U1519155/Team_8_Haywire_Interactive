using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GM_GameManager : MonoBehaviour
{
    public static bool bl_London;
    public static bool bl_Rome;
    public static bool bl_Dacca;
    public int in_Counter = 0;
    //public Text txt_Counter;
    //public static bool bl_EndLevel = false;

    // Use this for initialization
    void Awake ()
    {
        DontDestroyOnLoad(gameObject);
	}

    void SetBools()
    {
        bl_London = false;
        bl_Dacca = false;
        bl_Rome = false;
        in_Counter = 0;
    }

    // Update is called once per frame
    void Update ()
    {
        //txt_Counter.text = "Suspicion Level: " + in_Counter;

        if (in_Counter <= 0)
        {
            in_Counter = 0;
        }

        //if (bl_EndLevel == true)
        //{
        //    SetBools();
        //    GameObject.Find("GM_NextLevel").GetComponent<GM_NextLevel>().GoToNextLevel();
        //}
    }

    public void London()
    {
        if (bl_London == true)
        {
            Debug.Log("Correct!");
            in_Counter--;
           // bl_EndLevel = true;
        }

        else if (bl_London == false)
        {
            Debug.Log("Wrong :(");
            in_Counter++;
        }
    }

    public void Milan()
    {
        if (bl_Rome == true)
        {
            Debug.Log("Correct!");
            in_Counter--;
            //bl_EndLevel = true;
        }

        else if (bl_Rome == false)
        {
            Debug.Log("Wrong :(");
            in_Counter++;
        }
    }

    public void Dacca()
    {
        if (bl_Dacca == true)
        {
            Debug.Log("Correct!");
            in_Counter--;
           // bl_EndLevel = true;
        }

        else if (bl_Dacca == false)
        {
            Debug.Log("Wrong :(");
            in_Counter++;
        }
    }
}