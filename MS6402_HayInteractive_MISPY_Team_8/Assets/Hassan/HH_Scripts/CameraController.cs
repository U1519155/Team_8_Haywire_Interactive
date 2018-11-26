using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    Vector2 mouseLook; //keeps track of how much movement the mouse has made
    Vector2 SmoothVector; // smooths movement of mouse
    public float mouseSensitivity = 5.0f;
    public float smoothing = 2.0f;
    GameObject go_PC;
	// Use this for initialization
	void Start () {
        go_PC = this.transform.parent.gameObject; //sets go_PC to the parent of the camera
	}
	
	// Update is called once per frame
	void Update () {
        var mouseChange = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        mouseChange = Vector2.Scale(mouseChange, new Vector2(mouseSensitivity * smoothing, mouseSensitivity * smoothing));
        SmoothVector.x = Mathf.Lerp(SmoothVector.x, mouseChange.x, 1f / smoothing); // creates smooth movement on the x
        SmoothVector.y = Mathf.Lerp(SmoothVector.y, mouseChange.y, 1f / smoothing);// creates smooth movement on the y 
        mouseLook += SmoothVector; //smoothing calculations added to mouselook

        mouseLook.y = Mathf.Clamp(mouseLook.y, -75F, 75f); // a clamp to stop the camera from going upside down

        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right); // rotates the camera up and down
        go_PC.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, go_PC.transform.up); //rotates the camera and player left and right


    }
}
