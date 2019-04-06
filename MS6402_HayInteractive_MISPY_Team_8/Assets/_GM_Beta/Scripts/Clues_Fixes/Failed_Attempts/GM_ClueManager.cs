using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM_ClueManager : MonoBehaviour
{
    private bool bl_Generating = true;
    private int in_One;
    private int in_Two;
    private int in_Three;
    private string First = null;
    private string Second = null;
    private string Third = null;

    [Header("5 elements each")]
    public Text[] txt_UnderButtons;
    public GameObject[] go_Clues;

    // Start is called before the first frame update
    void Start()
    {
        First = GM_NewCodeGen.st_First;
        Second = GM_NewCodeGen.st_Second;
        Third = GM_NewCodeGen.st_Third;
    }

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject i in go_Clues)
        {
            if (i.activeInHierarchy == true)
            {
                //i.
            }
        }

        if (bl_Generating == true)
        {
            //in_One =
        }
    }
}
