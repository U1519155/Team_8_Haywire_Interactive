using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DD_NW_Spawn_Objects : NetworkBehaviour
{

    public GameObject go_crate;
    public Transform tx_spawn_pos;

    // Use this for initialization
    void Start()
    {
        if (isServer)
        {

            CmdSpawnObjects(tx_spawn_pos.position, tx_spawn_pos.rotation);
        }

    }//-----



    // ----------------------------------------------------------------------
    [Command]
    void CmdSpawnObjects(Vector3 _v3_pos, Quaternion _q_rot)
    {
        // Create a block on the server
        var _block = Instantiate(go_crate, _v3_pos, _q_rot);

        NetworkServer.Spawn(_block); // The object to spawn must be specified in the NW Manager
    }//-----  

}
