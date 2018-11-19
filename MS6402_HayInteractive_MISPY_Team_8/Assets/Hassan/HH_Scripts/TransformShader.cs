using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformShader : MonoBehaviour {
    
    Renderer rRenderer;
    float fl_bouncing;

    // Use this for initialization
    void Start () {
        
        rRenderer = GetComponent<Renderer>();
        rRenderer.material.shader = Shader.Find("Outlined/Custom Constant Width");
	}
	
	// Update is called once per frame
	void Update () {

        fl_bouncing = Mathf.PingPong(Time.time, 1.0f);
        rRenderer.material.SetFloat("Outline width", fl_bouncing);
	}
}
