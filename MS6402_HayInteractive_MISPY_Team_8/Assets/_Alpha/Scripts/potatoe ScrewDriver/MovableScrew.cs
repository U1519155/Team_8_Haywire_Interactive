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

    public float maxMovement = 6;

     void Start()
    {
        startPos = gameObject.transform.localPosition;
        goalPos = startPos + Vector3.forward * maxMovement;
    }

    // Update is called once per frame
    void Update()
    {
        endPos = gameObject.transform.localPosition;
        
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
        transform.localPosition += Vector3.forward *3* Time.deltaTime;

        
       
        
    }
}
