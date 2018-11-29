using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformShader : MonoBehaviour {

    Material thisMaterial;
    //Shader thisShader;
    public static float changevalue = 0.0f;
    //[Header("Outline Width")][Range(0, 5)]
    //public float fl_bouncing;

    // Use this for initialization
    void Start () {

        thisMaterial = this.GetComponent<Renderer>().material;
        //thisShader = thisMaterial.shader;
        
    }
	
	// Update is called once per frame
	void Update () {
        this.thisMaterial.SetFloat("_Outline", changevalue);
        //fl_bouncing = Mathf.PingPong(Time.time, 1.0f);

    }
}
