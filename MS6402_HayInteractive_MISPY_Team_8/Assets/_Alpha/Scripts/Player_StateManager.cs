using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Player_StateManager : MonoBehaviour
{
    public enum PC_different_states
    {
        pc_normal,
        pc_restricted,
        pc_screwDriver,
        pc_Watch,
        pc_Cigar
    }
    public static PC_different_states pc_State = PC_different_states.pc_normal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (pc_State)
        {
            case PC_different_states.pc_normal:

                break;
            case PC_different_states.pc_restricted:

                break;
            case PC_different_states.pc_screwDriver:

                break;
            case PC_different_states.pc_Watch:

                break;
            case PC_different_states.pc_Cigar:

                break;


        }
    }
}
