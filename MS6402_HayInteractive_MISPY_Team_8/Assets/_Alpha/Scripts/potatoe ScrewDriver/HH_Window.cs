using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HH_Window : MonoBehaviour
{
    //public GameObject[] Screws;
    private List<GameObject> Screwss = new List<GameObject>();

    bool windowOpened = false;
    public bool hitScrew;

    void Awake()
    {
        foreach (MovableScrew screw in GetComponentsInChildren<MovableScrew>())
        {
            Screwss.Add(screw.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        hitScrew = false;
    }

    // Update is called once per frame
    void Update()
    {
        int int_Screws = Screwss.Count;

        if (windowOpened == false)
        {
            if (Screwss.Count > 0)
            {
                for (int i = 0; i < Screwss.Count; i++)
                {
                    if (!Screwss[i].activeInHierarchy)
                    {
                        int_Screws--;
                        Debug.Log("LOST A SCREW");
                        Screwss.Remove(Screwss[i]);
                    }
                }
            }

            if (Screwss.Count == 0)
            {
                print("No More Screws Left");
            }
        }
        
        if (int_Screws == 0)
        {
            // DO SOMETHING TO THE WINDOW
            Debug.Log("hellow you opended the windo");
            gameObject.SetActive(false);
            
            windowOpened = true;
        }
    }
}
