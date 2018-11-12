using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_SimpleMovementV3 : MonoBehaviour {

    public float fl_MoveSpeed;
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetKey("w"))
        {
            this.transform.position += new Vector3(0, fl_MoveSpeed * Time.deltaTime, 0);
        }

        if (Input.GetKey("s"))
        {
            this.transform.position -= new Vector3(0, fl_MoveSpeed * Time.deltaTime, 0);
        }
	}
}
