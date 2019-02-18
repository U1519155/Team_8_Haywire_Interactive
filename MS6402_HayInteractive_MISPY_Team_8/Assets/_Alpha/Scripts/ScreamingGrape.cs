using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamingGrape : MonoBehaviour
{
    public static GameObject go_grape;
    
     
    // Start is called before the first frame update
    void Start()
    {
        go_grape = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void GrapeDestroy()
    {       
        Destroy(go_grape);
    }
}
