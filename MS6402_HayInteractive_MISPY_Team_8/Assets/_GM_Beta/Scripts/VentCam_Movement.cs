using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentCam_Movement : MonoBehaviour
{
    //Variables
    public float fl_Speed = 1.2f;
    public float fl_Y_Down_Value = 0;
    public float fl_Y_Up_Value = 0;
    public float fl_X_Down_Value = 0;
    public float fl_X_Up_Value = 0;
    public float fl_Z_Down_Value = 0;
    public float fl_Z_Up_Value = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeInHierarchy == true)
        {
            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                gameObject.transform.position += new Vector3(fl_X_Down_Value * Time.deltaTime * fl_Speed, fl_Y_Down_Value * Time.deltaTime * fl_Speed, fl_Z_Down_Value * Time.deltaTime * fl_Speed);
            }

            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
                gameObject.transform.position += new Vector3(fl_X_Up_Value * Time.deltaTime * fl_Speed, fl_Y_Up_Value * Time.deltaTime * fl_Speed, fl_Z_Up_Value * Time.deltaTime * fl_Speed);
            }
        }
    }
}