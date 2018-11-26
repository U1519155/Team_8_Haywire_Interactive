using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC_Controller : MonoBehaviour {

    public float playerSpeed = 10.0f;
    Rigidbody rb_PC;


    // Use this for initialization
    void Start () {
        Cursor.lockState = CursorLockMode.Locked; //cursor will not move our of screen
        rb_PC = GetComponent<Rigidbody>();
        

    }
	
	// Update is called once per frame
	void Update () {
        CharacterJump();

        float zMovement = (Input.GetAxis("Vertical") * playerSpeed) * Time.deltaTime; //smooth motion for forward and back (the z axis)
        float xMovement = (Input.GetAxis("Horizontal") * playerSpeed) * Time.deltaTime;//smooth motion for left and right (the x axis)

        transform.Translate(xMovement, 0, zMovement);

        if (Input.GetKeyDown(KeyCode.Escape))//unlock mouse cursor
        {
            Cursor.lockState = CursorLockMode.None;
        }

       

    }
    void CharacterJump() //using raycast to check if player is grounded
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb_PC.AddForce(Vector3.up * 5, ForceMode.Impulse);
        }
    }
}
