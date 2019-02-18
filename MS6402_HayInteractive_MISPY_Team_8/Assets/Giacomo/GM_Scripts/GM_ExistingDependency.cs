using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_ExistingDependency : MonoBehaviour
{
    public GameObject go_Dependency;
	
	// Update is called once per frame
	void Update ()
    {
        if (go_Dependency.activeInHierarchy == false)
        {
            gameObject.SetActive(false);
        }
	}
}