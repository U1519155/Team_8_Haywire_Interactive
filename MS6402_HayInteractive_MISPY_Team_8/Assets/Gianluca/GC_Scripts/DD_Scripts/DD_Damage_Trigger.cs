using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DD_Damage_Trigger : MonoBehaviour
{
   public float fl_damage_rate = -30;

    private void OnTriggerStay(Collider _cl_touching)
    {

        _cl_touching.SendMessage("Damage", fl_damage_rate * Time.deltaTime, SendMessageOptions.DontRequireReceiver);

    }//-----

    // note that the object this is attached to needs a rigidbody to work

}//==========
