using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GC_PC_trespass : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "PC")
        {
            if (Player_StateManager.pc_State != Player_StateManager.PC_different_states.pc_restricted)
            {
                Player_StateManager.pc_State = Player_StateManager.PC_different_states.pc_restricted;
                GM_Suspicion.bl_PCwanted = true;
            }
            if(Player_StateManager.pc_State == Player_StateManager.PC_different_states.pc_restricted)
            {

            }

        }
    }

    //public void OnTriggerExit(Collider other)
    //{
    //    GM_Suspicion.bl_PCwanted = false;
    //}
}
