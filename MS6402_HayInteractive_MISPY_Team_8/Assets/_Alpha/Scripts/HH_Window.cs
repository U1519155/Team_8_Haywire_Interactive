using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HH_Window : MonoBehaviour
{
    public GameObject[] Screws;
    bool windowOpened = false;
    public bool hitScrew;
    
    


    // Start is called before the first frame update
    void Start()
    {
        hitScrew = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        int int_Screws = Screws.Length;

        if (windowOpened == false)
        {
            foreach (GameObject screw in Screws) // able to transform one game object
            {
                
                if (screw.activeSelf == false)
                {
                    int_Screws--;
                    Debug.Log("LOST A SCREW");

                }
            }
        }
        

        if (int_Screws < 1)
        {
            // DO SOMETHING TO THE WINDOW
            Debug.Log("hellow you opended the windo");
            
            windowOpened = true;
        }
    }
}
