using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GC_PC_trespass : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "PC")
        {
            GM_Suspicion.bl_PCwanted = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        GM_Suspicion.bl_PCwanted = false;
    }
}
