using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float MaxRange = 5.0f;
    public float outlineSize = 1.3f;
    public Camera cam;
    public GameObject screw;
    public GameObject glassCase;
    public GameObject diamond;
    
    public GameObject doorExit;
    public GameObject doorExitScrew;

    public GameObject outDoorExitScrew;
   // public GameObject doorEnter;

    public bool bl_Diamond = false;
    // Use this for initialization
    void Start()
    {

        cam = Camera.main;
       // doorEnter.SetActive(false);
       // doorExit.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        CameraRaycast();
    }

    void CameraRaycast()
    {
        RaycastHit hit;
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, MaxRange))
        {

            if (hit.collider.tag == "Interactable")
            {
                TransformShader.changevalue = outlineSize;
            }
            else if (hit.collider.tag != "Interactable" || hit.collider == null)
            {
                TransformShader.changevalue = 0f;
            }
            #region screw case Diamond Doors
            if (hit.collider.name == "Screw")
            {
                if (Input.GetKey(KeyCode.F))
                {
                    screw.transform.Translate(Vector3.forward * Time.deltaTime);
                    screw.transform.Rotate(0, 0, 360 * Time.deltaTime);
                    Destroy(screw, 0.7f);
                }
            }

            if(screw == null)
            {
                if (glassCase != null)
                {
                    glassCase.transform.Translate(Vector3.up * Time.deltaTime);
                    glassCase.transform.Rotate(-65 * Time.deltaTime, 0, 0);
                    Destroy(glassCase, 1.7f);
                }

                
                if (hit.collider.name == "Diamond")
                {
                    if (Input.GetKey(KeyCode.F))
                    {
                        Destroy(diamond, 1.2f);
                        bl_Diamond = true;
                    }
                }
            }

            
                //doorExit.SetActive(true);
                //doorEnter.SetActive(true);

                if (hit.collider.name == "Door_Screw")
                {
                    if (Input.GetKey(KeyCode.F))
                    {
                        doorExitScrew.transform.Rotate(360 * Time.deltaTime, 0, 0);
                        Destroy(doorExitScrew, 3f);
                    }

                }
                if (doorExitScrew == null)
                {
                    doorExit.transform.Translate(Vector3.right * Time.deltaTime);
                    doorExit.transform.Rotate(0, -100 * Time.deltaTime, 0);
                    Destroy(doorExit, 0.8f);
                }

            if (hit.collider.name == "Door_Screw_out")
            {
                if (Input.GetKey(KeyCode.F))
                {
                    outDoorExitScrew.transform.Rotate(360 * Time.deltaTime, 0, 0);
                    Destroy(doorExitScrew, 3f);
                }

            }
            if (outDoorExitScrew == null)
            {
                doorExit.transform.Translate(Vector3.right * Time.deltaTime);
                doorExit.transform.Rotate(0, 100 * Time.deltaTime, 0);
                Destroy(doorExit, 0.8f);
            }

            #endregion

            Debug.Log(hit.transform.name);
            Debug.DrawRay(cam.transform.position, transform.forward * MaxRange);
        }

    }
}
