using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableScrew : MonoBehaviour
{
    [SerializeField]
     Vector3 startPos;
    [SerializeField]
     Vector3 endPos;
    [SerializeField]
     Vector3 goalPos;
    

     void Start()
    {
        startPos = gameObject.transform.position;
        goalPos = startPos + Vector3.forward/2;
    }

    // Update is called once per frame
    void Update()
    {
        endPos = gameObject.transform.position;
        
    }

    public void Rotate()
    {
        // Do your thing.
        if (endPos.z > goalPos.z)
        {
            Debug.Log("YOU HAVE REACHED YOUR DESTINY");
            gameObject.SetActive(false);

        }
        transform.Rotate(0, 0, 20);
        transform.position += Vector3.forward / Mathf.Exp(5); 

        
       
        
    }
}
